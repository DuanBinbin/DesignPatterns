package com.db.crash;

import java.io.File;
import java.io.FileOutputStream;
import java.io.PrintWriter;
import java.io.StringWriter;
import java.io.Writer;
import java.lang.reflect.Field;
import java.text.DateFormat;
import java.text.SimpleDateFormat;
import java.util.Date;
import java.util.HashMap;
import java.util.Map;

import android.annotation.SuppressLint;
import android.app.Dialog;
import android.content.Context;

import android.content.DialogInterface;
import android.content.pm.ApplicationInfo;
import android.content.pm.PackageInfo;
import android.content.pm.PackageManager;
import android.os.Build;
import android.os.Environment;
import android.os.Looper;
import android.support.v7.app.AlertDialog;
import android.util.Log;
import android.view.WindowManager;
import android.widget.Toast;

/**
 * @描述：     @全局捕获异常信息,发生Uncaught异常时，又该类来接管程序
 * @作者：     @Bin
 * @创建时间： @2019/1/24 15:08
 */
public class CrashHandler implements Thread.UncaughtExceptionHandler {

    private static final String TAG = "CrashHandler";

    private Context mContext;

    @SuppressLint("StaticFieldLeak")
    private static CrashHandler instance ;

    //系统默认的UncaughtException处理类
    private Thread.UncaughtExceptionHandler mDefaultUEHandler ;

    //用来存储设备信息和异常信息
    private Map<String,String> deviceInfo = new HashMap<>();

    //格式化日期
    @SuppressLint("SimpleDateFormat")
    private DateFormat dateFormat = new SimpleDateFormat("yyyy-MM-dd");

    public UpdateErrorInfoListener delegate;

    private CrashHandler(){

    }

    public static CrashHandler getInstance(){
        if (instance == null){
            synchronized (CrashHandler.class){
                if (instance == null){
                    instance = new CrashHandler();
                }
            }
        }
        return instance;
    }

    public void init(Context context,UpdateErrorInfoListener listener){
        this.mContext = context;
        this.delegate = listener;
        //设置该CrashHandler为程序的默认处理器
        Thread.setDefaultUncaughtExceptionHandler(this);
        //获取系统默认UncaughtException处理器
        mDefaultUEHandler = Thread.getDefaultUncaughtExceptionHandler();
    }

    /**
     * 当UncaughtExcept发生时会转入该函数来处理
     * @param thread
     * @param throwable
     */
    @Override
    public void uncaughtException(Thread thread, Throwable throwable) {
        Log.i(TAG, "uncaughtException: 先捕捉到");

//        if (AppParams.DEBUG_EX){ //调试的时候，记得将DEBUG_EX置成True，
        if (isApkInDebug(mContext)){

            Log.i(TAG, "uncaughtException: 被系统机制开始处理,app开始崩溃");
            //交由系统默认的错误处理器来处理，也就是"崩溃报错"
            mDefaultUEHandler.uncaughtException(thread,throwable);
        }

        if (handleException(throwable)){
            Log.i(TAG, "uncaughtException: 运行到这里");
            // showDialog(mContext);
            //表示被自己写的handlerException处理了，进行收尾操作
            // SystemClock.sleep(3000);
            Log.i(TAG, "uncaughtException: CrashHandler处理了");
        }else {
            //自己的CrashHandler没有捕捉到异常，交由系统机制进行崩溃处理
            mDefaultUEHandler.uncaughtException(thread,throwable);
        }

        Log.i(TAG, "uncaughtException: 后捕捉到");
    }

    /**
     * 自定义错误处理，收集错误信息，发送错误报告等操作
     *
     * @param ex
     * @return true:如果处理了该错误信息返回true，否则返回false
     */
    private boolean handleException(final Throwable ex){
        if (ex == null){
            return false;
        }
        try {
            Log.i(TAG, "handleException: 发现了个错误，处理中....");
            new Thread(){
                @Override
                public void run() {
                    Looper.prepare();
                    Toast.makeText(mContext, "发现个错误", Toast.LENGTH_SHORT).show();
                    Log.i(TAG, "run: " + ex.toString());

                    showDialog(mContext);
                    Looper.loop();
                    // showDialog(mContext);
                }
            }.start();
            Log.i(TAG, "handleException: CrashHandler处理完成");
        }catch (Exception e){
            e.printStackTrace();
        }
        return true;
    }

    /**
     * 收集设备参数信息
     *
     * @param ctx
     */
    public void collectDeviceInfo(Context ctx) {
        try {
            PackageManager pm = ctx.getPackageManager();
            PackageInfo pi = pm.getPackageInfo(ctx.getPackageName(),
                    PackageManager.GET_ACTIVITIES);

            if (pi != null) {
                String versionName = pi.versionName == null ? "null"
                        : pi.versionName;
                String versionCode = pi.versionCode + "";
                deviceInfo.put("versionName", versionName);//版本名称
                deviceInfo.put("versionCode", versionCode);//版本号
            }
        } catch (PackageManager.NameNotFoundException e) {
            Log.e(TAG, "an error occurred when collect package info", e);
        }
        Field[] fields = Build.class.getDeclaredFields();
        for (Field field : fields) {
            try {
                field.setAccessible(true);
                deviceInfo.put(field.getName(), field.get(null).toString());
            } catch (Exception e) {
                Log.e(TAG, "an error occurred when collect crash info", e);
            }
        }
    }

    /**
     * 保存错误信息
     *
     * @param ex
     * @return 返回文件名称,便于将文件传送到服务器
     */
    private String saveCrashInfo2File(Throwable ex) {
        StringBuffer sb = new StringBuffer ();
        for (Map.Entry<String, String> entry : deviceInfo.entrySet()) {
            String key = entry.getKey();
            String value = entry.getValue();
            sb.append(key + "=" + value + "\n");
        }

        Writer writer = new StringWriter();
        PrintWriter printWriter = new PrintWriter (writer);
        ex.printStackTrace(printWriter);
        Throwable cause = ex.getCause();
        while (cause != null) {
            cause.printStackTrace(printWriter);
            cause = cause.getCause();
        }
        printWriter.close();

        String result = writer.toString();
        sb.append(result);
        Log.e(TAG,sb.toString());//答应错误信息
        /******************************/
        //上传服务器
        delegate.onUpdateErrorInfo(sb.toString());


        String filePath = "";
        try {
            long timestamp = System.currentTimeMillis();
            String time = dateFormat.format(new Date());
            String fileName = "error-" + time + "-" + timestamp + ".log";
            if (Environment.getExternalStorageState().equals(
                    Environment.MEDIA_MOUNTED)) {
                String path = Environment.getExternalStorageDirectory()
                        .getAbsolutePath() + "/crashs";
//                Toast.makeText(mContext, path, Toast.LENGTH_LONG).show();
                File dir = new File (path);
                if (!dir.exists()) {
                    dir.mkdirs();
                }
                filePath = path + fileName;
                FileOutputStream fos = new FileOutputStream (path + fileName);
                fos.write(sb.toString().getBytes());
                fos.flush();
                fos.close();
            }
            return filePath;
        } catch (Exception e) {
            Log.e(TAG, "an error occured while writing file...", e);
        }

        return null;
    }

    public interface UpdateErrorInfoListener
    {
        void onUpdateErrorInfo(String str);
    }

    private void showDialog(Context context){
        AlertDialog.Builder builder = new AlertDialog.Builder(context);
        builder.setMessage(context.getResources().getString(R.string.app_crashHandler_dialog_summary));
        builder.setTitle(context.getResources().getString(R.string.app_crashHandler_dialog_title));
        builder.setPositiveButton(context.getResources().getString(R.string.app_crashHandler_dialog_upload)
                , new DialogInterface.OnClickListener() {
                    @Override
                    public void onClick(DialogInterface dialog, int which) {
                        Log.i(TAG, "onClick: 上传错误日志");
                        dialog.dismiss();

                    }
                });
        builder.setNegativeButton(context.getResources().getString(R.string.app_crashHandler_dialog_reIndex)
                , new DialogInterface.OnClickListener() {
                    @Override
                    public void onClick(DialogInterface dialog, int which) {
//                        Index.getInstance().switchFragment(AppParams.FragMenuList);
                        dialog.dismiss();
                    }
                });
        Dialog dialog=builder.create();
        dialog.getWindow().setType(WindowManager.LayoutParams.TYPE_SYSTEM_ALERT);
        dialog.show();
    }

    /**
     * 判断当前应用是否是Debug状态
     * @param context
     *
     * @return
     */
    private boolean isApkInDebug(Context context){
        try {
            ApplicationInfo appInfo = context.getApplicationInfo();
            return (appInfo.flags & ApplicationInfo.FLAG_DEBUGGABLE) != 0;
        } catch (Exception e){
            return false;
        }
    }

}



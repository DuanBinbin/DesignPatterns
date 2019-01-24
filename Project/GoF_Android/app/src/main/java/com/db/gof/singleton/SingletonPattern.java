package com.db.gof.singleton;

import android.app.Application;
import android.content.Context;
import android.view.WindowManager;


/**
 * @描述：     @单利模式
 * @作者：     @Bin
 * @创建时间： @2019/1/23 20:30
 * @定义：确保单例类只有一个实例，并且这个单例类提供一个函数接口让其他类获取到这个唯一的实例。
 * @使用场景：   如果某个类，创建时需要消耗很多资源，即new出这个类的代价很大；或者是这个类占用很多内存，
 *              如果创建太多这个类实例会导致内存占用太多
 */
public class SingletonPattern {

    private Context mContext;
    private WindowManager mWindowManager;

    public SingletonPattern(Context context){
        this.mContext = context;
    }

    private void getWindowManager(){
        if (null != mContext){
            mWindowManager = (WindowManager) mContext.getSystemService(Application.WINDOW_SERVICE);
        }
    }
}

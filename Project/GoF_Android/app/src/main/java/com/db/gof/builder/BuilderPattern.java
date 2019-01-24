package com.db.gof.builder;

import android.app.AlertDialog;
import android.content.Context;
import android.content.DialogInterface;
import android.util.Log;

/**
 * @描述：     @建造者模式
 * @作者：     @Bin
 * @创建时间： @2019/1/24 12:11
 * @定义：     @将一个复杂对象的构造与他的表示分离，使得同样的构造过程可以创建不同的表示
 * @使用场景： @主要是在创建某个对象时，需要设定很多的参数（通过Setter方法），但是这些参数必须
 *              按照某个顺序设定，或者是设置步骤不同会得到不同的结果
 */
public class BuilderPattern {

    /**
     * 显示AlertDialog
     * @param context
     */
    private void showAlertDialog(Context context){
        AlertDialog.Builder builder = new AlertDialog.Builder(context);
        builder.setTitle("Title")
                .setMessage("Message")
                .setPositiveButton("AlertDialogBtn", new DialogInterface.OnClickListener() {
                    @Override
                    public void onClick(DialogInterface dialog, int which) {
                        Log.d("BuilderPattern","showAlertDialog");
                    }
                })
                .create().show();
    }
}

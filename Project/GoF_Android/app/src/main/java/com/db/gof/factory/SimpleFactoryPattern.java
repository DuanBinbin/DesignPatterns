package com.db.gof.factory;

import android.content.Context;

/**
 * @描述：     @简单工厂模式
 * @作者：     @Bin
 * @创建时间： @2019/1/28 16:03
 * @定义：建立一个工厂（一个函数或一个类方法）来制造新的对象
 */
public class SimpleFactoryPattern {

    /*********************** Android **************************/
    public void getSystemService(Context context,String name){
        context.getSystemService(name);
    }
}

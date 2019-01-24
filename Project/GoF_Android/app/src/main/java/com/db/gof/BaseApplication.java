package com.db.gof;

import android.app.Application;
import android.content.Context;

/**
 * @描述：     @自定义Application基类
 * @作者：     @Bin
 * @创建时间： @2019/1/23 20:34
 */
public final class BaseApplication extends Application {

    private static Context mContext;

    @Override
    public void onCreate() {
        super.onCreate();
        mContext = this;
    }

    public static Context getContext(){
        return mContext;
    }
}

package com.db.gof.demeter;

import android.util.Log;

/**
 * @描述：     @租户
 * @作者：     @Bin
 * @创建时间： @2019/1/30 11:58
 */
public class Tenant {

    public float roomArea;
    public float roomPrice;

    /**
     * ReadOnly
     */
    public static final float diffPrice = 100.0001f;
    /**
     * ReadOnly
     */
    public static final float diffArea = 0.00001f;

    public void rentRoom(Mediator mediator){
        Log.d("Tenant","租到房啦 " + mediator.rentOut(roomArea,roomPrice));
    }
}

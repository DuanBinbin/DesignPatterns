package com.db.gof.utils;

import java.io.Closeable;
import java.io.IOException;

/**
 * @描述：     @关闭类
 * @作者：     @Bin
 * @创建时间： @2019/1/30 11:27
 */
public final class CloseUtils {

    private CloseUtils(){

    }

    /**
     * 关闭Closeable对象
     * @param closeable
     */
    public static void closeQuietly(Closeable closeable){
        if (null != closeable){
            try{
                closeable.close();
            } catch (IOException e){
                e.printStackTrace();
            }
        }
    }
}

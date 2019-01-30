package com.db.gof.loader;

import android.graphics.Bitmap;

/**
 * @描述：     @双缓存：获取图片时先从内存缓存中获取，如果内存中没有缓存该图片，再从SD卡中获取。
 *              缓存图片也是在内存和SD卡中都缓存一份
 * @作者：     @Bin
 * @创建时间： @2019/1/29 17:39
 */
public class DoubleCache implements ImageCache{

    private MemoryCache mMemoryCache = new MemoryCache();
    private DiskCache mDiskCache = new DiskCache();

    /**
     * 先从内存缓存中获取图片，如果没有，再从SD卡中获取
     * @param url
     * @return
     */
    @Override
    public Bitmap get(String url){
        Bitmap bmp = mMemoryCache.get(url);
        if (null == bmp){
            bmp = mDiskCache.get(url);
        }
        return bmp;
    }

    /**
     * 将图片缓存到内存和SD卡中
     * @param url
     * @param bitmap
     */
    @Override
    public void put(String url,Bitmap bitmap){
        mMemoryCache.put(url, bitmap);
        mDiskCache.put(url, bitmap);
    }

}

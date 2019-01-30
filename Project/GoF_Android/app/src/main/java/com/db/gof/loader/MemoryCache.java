package com.db.gof.loader;

import android.graphics.Bitmap;
import android.util.LruCache;

/**
 * @描述：     @图片缓存类
 * @作者：     @Bin
 * @创建时间： @2019/1/29 16:55
 */
public class MemoryCache implements ImageCache {

    /**
     * 图片缓存类
     */
    private LruCache<String,Bitmap> mMemoryCache;

    public MemoryCache(){
        initImageCache();
    }

    /**
     * 初始化
     */
    private void initImageCache(){
        //计算可使用的最大内存
        final int maxMemory = (int) (Runtime.getRuntime().maxMemory() / 1024);
        //去四分之一的可用内存作为缓存
        final int cacheSize = maxMemory / 4;

        mMemoryCache = new LruCache<String,Bitmap>(cacheSize){
            @Override
            protected int sizeOf(String key, Bitmap value) {
                return value.getRowBytes() * value.getHeight() / 1024;
            }
        };
    }

    @Override
    public void put(String url,Bitmap bitmap){
        mMemoryCache.put(url, bitmap);
    }

    @Override
    public Bitmap get(String url){
        return mMemoryCache.get(url);
    }

}

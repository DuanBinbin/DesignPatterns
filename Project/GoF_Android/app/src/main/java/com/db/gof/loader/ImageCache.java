package com.db.gof.loader;

import android.graphics.Bitmap;

/**
 * @描述：     @图片缓存接口，用来抽象图片缓存的功能
 * @作者：     @Bin
 * @创建时间： @2019/1/29 18:17
 */
public interface ImageCache {
    Bitmap get(String url);
    void put(String url,Bitmap bitmap);
}

package com.db.gof.principle;

import android.graphics.Bitmap;
import android.graphics.BitmapFactory;
import android.widget.ImageView;

import java.net.HttpURLConnection;
import java.net.URL;
import java.util.concurrent.ExecutorService;
import java.util.concurrent.Executors;

import javax.xml.parsers.FactoryConfigurationError;

/**
 * @描述：     @图片加载器，通过实现此类来学习面向对象的6大原则
 * @作者：     @Bin
 * @创建时间： @2019/1/29 16:25
 * @单一职责原则（SRP)：就一个类而言，应该仅有一个引起变化的原因，简单来说，一个类中应该是一组相关性
 *                     很高的函数、数据的封装。-- 优化代码的第一步
 * @开闭原则（OCP）：软件中的对象（类、模块、函数等）应该对于扩展是开放的，但是，对于修改是封闭的。
 *                  -- 让程序更稳定、更灵活
 * @里氏替换原则
 */
public class ImageLoader {

    /**
     * 内存缓存类
     */
    private ImageCache mImageCache = new ImageCache();

    /**
     * SD 卡缓存
     */
    private DiskCache mDiskCache = new DiskCache();

    /**
     * 是否使用SD卡缓存
     */
    private boolean isUseDiskCache = false;

    /**
     * 设置是否使用 SD卡缓存
     * @param useDiskCache
     */
    public void setUseDiskCache(boolean useDiskCache) {
        isUseDiskCache = useDiskCache;
    }

    /**
     * 线程池，线程数量为CPU的数量
     */
    private ExecutorService mExecutorService = Executors.newFixedThreadPool(
            Runtime.getRuntime().availableProcessors());

    public ImageLoader(){

    }

    /**
     * 加载图片
     * @param url
     * @param imageView
     */
    public void displayImage(final String url, final ImageView imageView){
        Bitmap bitmap = isUseDiskCache ? mDiskCache.get(url) : mImageCache.get(url);

        if (null != bitmap){
            imageView.setImageBitmap(bitmap);
            return;
        }

        imageView.setTag(url);
        mExecutorService.submit(new Runnable() {
            @Override
            public void run() {
                Bitmap bitmap = downloadImage(url);
                if (bitmap == null){
                    return;
                }
                if (imageView.getTag().equals(url)){
                    imageView.setImageBitmap(bitmap);
                }
                mImageCache.put(url,bitmap);
            }
        });
    }



    /**
     * 下载图片
     * @param imageUrl
     * @return
     */
    public Bitmap downloadImage(String imageUrl){
        Bitmap bitmap = null;
        try{
            URL url = new URL(imageUrl);
            final HttpURLConnection conn = (HttpURLConnection) url.openConnection();
            bitmap = BitmapFactory.decodeStream(conn.getInputStream());
            conn.disconnect();
        } catch (Exception e){
            e.printStackTrace();
        }
        return bitmap;
    }

}

package com.db.gof.principle;

import android.graphics.Bitmap;
import android.graphics.BitmapFactory;
import android.util.LruCache;
import android.widget.ImageView;

import java.net.HttpURLConnection;
import java.net.URL;
import java.util.concurrent.ExecutorService;
import java.util.concurrent.Executors;

/**
 * @描述：     @图片加载器，通过实现此类来学习面向对象的6大原则
 * @作者：     @Bin
 * @创建时间： @2019/1/29 16:25
 */
public class ImageLoader {

    /**
     * 图片缓存类
     */
    private ImageCache mImageCache = new ImageCache();

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
        Bitmap bitmap = mImageCache.get(url);

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

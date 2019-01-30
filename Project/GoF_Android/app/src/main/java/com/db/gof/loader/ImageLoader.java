package com.db.gof.loader;

import android.graphics.Bitmap;
import android.graphics.BitmapFactory;
import android.widget.ImageView;

import java.net.HttpURLConnection;
import java.net.URL;
import java.util.concurrent.ExecutorService;
import java.util.concurrent.Executors;

/**
 * @描述：     @图片加载器，通过实现此类来学习面向对象的6大原则
 * @作者：     @Bin
 * @创建时间： @2019/1/29 16:25
 * @单一职责原则（SRP)：就一个类而言，应该仅有一个引起变化的原因，简单来说，一个类中应该是一组相关性
 *                     很高的函数、数据的封装。-- 优化代码的第一步
 * @开闭原则（OCP）：软件中的对象（类、模块、函数等）应该对于扩展是开放的，但是，对于修改是封闭的。
 *                  -- 让程序更稳定、更灵活
 * @里氏替换原则（LSP）：所有引用基类的地方必须能透明地使用其子类对的对象。
 *                  -- 构建扩展性更好的系统
 * @依赖倒置原则（DIP）：指代了一种特定的解耦形式，使得高层次的模块不依赖与低层次的模块的实现细节的目的。
 *                  -- 让项目拥有变化的能力
 * @接口隔离原则（ISP）：客户端不应该依赖他不需要的接口，或者说，类间的依赖关系应该建立在最小的接口上。
 *                  -- 系统有更高的灵活性
 * @迪比特原则（LOD）：一个对象应该对其他对象有最少的了解
 *
 * @总结：抽象、单一职责、最小化
 */
public class ImageLoader {

    /**
     * 内存缓存类
     */
    private ImageCache mImageCache;

    /**
     * 注释内存缓存
     * @param cache
     */
    public void setImageCache(ImageCache cache) {
        this.mImageCache = cache;
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
        Bitmap bitmap = mImageCache.get(url);

        if (null != bitmap){
            imageView.setImageBitmap(bitmap);
            return;
        }

        //图片没缓存，提交到线程池中下载图片
        submitLoadRequest(url, imageView);
    }

    /**
     * 从线程池中下载图片
     * @param imageUrl
     * @param imageView
     */
    private void submitLoadRequest(final String imageUrl,final ImageView imageView){
        imageView.setTag(imageUrl);
        mExecutorService.submit(new Runnable() {
            @Override
            public void run() {
                Bitmap bitmap = downloadImage(imageUrl);
                if (bitmap == null){
                    return;
                }
                if (imageView.getTag().equals(imageUrl)){
                    imageView.setImageBitmap(bitmap);
                }
                mImageCache.put(imageUrl,bitmap);
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

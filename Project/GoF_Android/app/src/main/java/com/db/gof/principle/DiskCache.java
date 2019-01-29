package com.db.gof.principle;

import android.graphics.Bitmap;
import android.graphics.BitmapFactory;
import android.os.Environment;

import java.io.File;
import java.io.FileNotFoundException;
import java.io.FileOutputStream;
import java.io.IOException;

/**
 * @描述：     @图片缓存类（SD Card）
 * @作者：     @Bin
 * @创建时间： @2019/1/29 17:13
 */
public class DiskCache {

    private final static String cacheDir =
            Environment.getExternalStorageState() + File.separator + "cache/";

    /**
     * 从缓存中获取图片
     * @param url
     * @return
     */
    public Bitmap get(String url){
        return BitmapFactory.decodeFile(cacheDir + url);
    }

    /**
     * 将图片缓存到内存中
     * @param url
     * @param bmp
     */
    public void put(String url,Bitmap bmp){
        FileOutputStream fos = null;
        try {
            fos = new FileOutputStream(cacheDir + url);
            bmp.compress(Bitmap.CompressFormat.PNG,100,fos);
        } catch (FileNotFoundException e){
            e.printStackTrace();
        } finally {
            if (null != fos){
                try{
                    fos.close();
                } catch (IOException e){
                    e.printStackTrace();
                }
            }
        }
    }


}

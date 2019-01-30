package com.db.gof.window;

/**
 * @描述：     @建立视图抽象，测量视图的宽高为公用代码，绘制实现交给具体的子类
 * @作者：     @Bin
 * @创建时间： @2019/1/30 10:37
 */
public abstract class View {

    /**
     * 绘制
     */
    public abstract void draw();

    public void messure(int width,int height){
        //测量视图大小
    }

}

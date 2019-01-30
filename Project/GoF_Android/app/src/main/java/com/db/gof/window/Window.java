package com.db.gof.window;

/**
 * @描述：     @窗口类
 * @作者：     @Bin
 * @创建时间： @2019/1/29 18:30
 * @里氏替换原则：所有引用基类的地方必须能透明地使用其子类对的对象。
 */
public class Window {

    public void show(View child){
        child.draw();
    }
}

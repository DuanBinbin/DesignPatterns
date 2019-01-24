package com.db.gof.prototype;

import android.content.Intent;
import android.net.Uri;

import java.io.Serializable;
import java.util.HashMap;
import java.util.Iterator;
import java.util.Map;

/**
 * @描述：     @原型模式
 * @作者：     @Bin
 * @创建时间： @2019/1/24 14:20
 * @定义：用原型实例指定创建对象的种类，并通过拷贝这些原型创建新的对象
 * @重构：如果存在逐一去除某个对象的各项参数值，转而赋值被另一个对象上时，便可使用原型模式
 */
public class PrototypePattern {

    private void androidExample(){
        Intent intent = new Intent(Intent.ACTION_SENDTO,Uri.parse(""));
        //克隆副本
        Intent copyIntent = (Intent) intent.clone();
    }

    private HashMap getClonePointMap(Map map) throws CloneNotSupportedException {
        HashMap clone = new HashMap();
        if (null != map){
            Iterator iterator = map.entrySet().iterator();
            while (iterator.hasNext()){
                Map.Entry entry = (Map.Entry) iterator.next();
                String key = (String) entry.getKey();
                PointBean pointBean = (PointBean) entry.getValue();
                if (null != pointBean){
                    clone.put(key,pointBean.clone());
                } else {
                    clone.put(key,null);
                }
            }
        }
        return clone;
    }

    public class PointBean implements Serializable{

        /**
         * 是否需要展示
         */
        protected boolean visible = true;


        public boolean isVisible() {
            return visible;
        }

        public void setVisible(boolean visible) {
            this.visible = visible;
        }

        public PointBean(){

        }

        @Override
        protected Object clone() throws CloneNotSupportedException {
            PointBean clonePoint = new PointBean();
            clonePoint.setVisible(visible);
            return clonePoint;
        }
    }
}

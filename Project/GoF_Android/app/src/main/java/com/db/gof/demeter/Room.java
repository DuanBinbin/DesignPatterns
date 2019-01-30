package com.db.gof.demeter;

/**
 * @描述：     @房间类
 * @作者：     @Bin
 * @创建时间： @2019/1/30 11:50
 */
public class Room {
    public float area;
    public float price;

    public Room(float area,float price){
        this.area = area;
        this.price = price;
    }

    @Override
    public String toString() {
        return "Room [area=" + area + ", price=" + price + "]";
    }
}

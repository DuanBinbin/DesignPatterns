package com.db.gof.demeter;

import java.util.ArrayList;
import java.util.List;

/**
 * @描述：     @中介类
 * @作者：     @Bin
 * @创建时间： @2019/1/30 11:53
 */
public class Mediator {

    private List<Room> mRoomsList = new ArrayList<>();

    public Mediator(){
        for (int i = 0; i < 5; i++){
            mRoomsList.add(new Room(14 + i,(14 + i) * 100));
        }
    }

    public Room rentOut(float area,float price){
        for (Room room : mRoomsList){
            if (isSuitable(area,price,room)){
                return room;
            }
        }
        return null;
    }

    private boolean isSuitable(float area,float price,Room room){
        return Math.abs(room.price - price) < Tenant.diffPrice
                && Math.abs(room.area - area) < Tenant.diffArea;
    }
}

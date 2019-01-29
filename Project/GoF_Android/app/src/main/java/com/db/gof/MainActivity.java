package com.db.gof;

import android.content.Context;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.View;
import android.view.WindowManager;

public class MainActivity extends AppCompatActivity implements View.OnClickListener{

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
        findViewById(R.id.btn_get_system_service).setOnClickListener(this);
    }

    @Override
    public void onClick(View v) {
        final int id = v.getId();
        switch (id){
            case R.id.btn_get_system_service:
                getWindowManagerService();
                break;
        }
    }

    private void getWindowManagerService(){
        final WindowManager wm = (WindowManager)getSystemService(Context.WINDOW_SERVICE);
    }
}

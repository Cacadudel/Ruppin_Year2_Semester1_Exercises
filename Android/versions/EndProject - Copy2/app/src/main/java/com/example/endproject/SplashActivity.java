package com.example.endproject; // ודא שהשם תואם לשם החבילה שלך

import android.app.Activity;
import android.content.Intent;
import android.os.Bundle;
import android.os.Handler;
import android.view.animation.Animation;
import android.view.animation.AnimationUtils;
import android.widget.ImageView;
import android.widget.TextView;

public class SplashActivity extends Activity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_splash);

        // מציאת הלוגו והטקסט
        ImageView logo = findViewById(R.id.logo);
        TextView text = findViewById(R.id.splashText);

        // טעינת האנימציה החדשה (Fade In + Zoom In)
        Animation fadeZoomIn = AnimationUtils.loadAnimation(this, R.anim.fade_zoom_in);

        // הפעלת האנימציה על הלוגו והטקסט
        logo.startAnimation(fadeZoomIn);
        text.startAnimation(fadeZoomIn);

        // מעבר למסך הראשי אחרי 3 שניות
        new Handler().postDelayed(new Runnable() {
            @Override
            public void run() {
                Intent intent = new Intent(SplashActivity.this, MainActivity.class);
                startActivity(intent);
                finish(); // סוגר את מסך הספלאש כך שלא יחזור בלחיצה על "חזור"
            }
        }, 3000);
    }
}

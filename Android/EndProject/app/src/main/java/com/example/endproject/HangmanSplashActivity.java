package com.example.endproject;

import android.content.Intent;
import android.graphics.drawable.AnimationDrawable;
import android.os.Bundle;
import android.os.Handler;
import android.widget.ImageView;

import androidx.appcompat.app.AppCompatActivity;

public class HangmanSplashActivity extends AppCompatActivity {

    private AnimationDrawable hangmanAnimation;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_hangman_splash);

        // התייחסות לתמונה במסך הפתיחה
        ImageView hangmanImageView = findViewById(R.id.splashHangmanImage);

        // הגדרת משאב האנימציה
        hangmanImageView.setBackgroundResource(R.drawable.hangman_animation);

        // קבלת האנימציה מהרקע
        hangmanAnimation = (AnimationDrawable) hangmanImageView.getBackground();
    }

    @Override
    protected void onStart() {
        super.onStart();
        // התחלת האנימציה
        hangmanAnimation.start();

        // הוספת השהייה לפני התחלת המשחק
        new Handler().postDelayed(() -> {
            // התחלת המשחק אחרי סיום האנימציה
            Intent intent = new Intent(HangmanSplashActivity.this, NewGameActivity.class);
            startActivity(intent);
            finish();
        }, 3500); // הצגת מסך פתיחה למשך 3.5 שניות
    }

    @Override
    protected void onPause() {
        super.onPause();
        if (hangmanAnimation != null && hangmanAnimation.isRunning()) {
            hangmanAnimation.stop();
        }
    }
}
package com.example.endproject;

import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;

import androidx.activity.EdgeToEdge;
import androidx.appcompat.app.AppCompatActivity;
import androidx.core.graphics.Insets;
import androidx.core.view.ViewCompat;
import androidx.core.view.WindowInsetsCompat;

public class MainActivity extends AppCompatActivity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        EdgeToEdge.enable(this);
        setContentView(R.layout.activity_main);

        ViewCompat.setOnApplyWindowInsetsListener(findViewById(R.id.main), (v, insets) -> {
            Insets systemBars = insets.getInsets(WindowInsetsCompat.Type.systemBars());
            v.setPadding(systemBars.left, systemBars.top, systemBars.right, systemBars.bottom);
            return insets;
        });

        // מציאת הכפתורים
        Button guessNumberButton = findViewById(R.id.guessNumberButton);
        Button fillDetailsButton = findViewById(R.id.fillDetailsButton);
        Button calculatorButton = findViewById(R.id.calculatorButton);
        Button newGameButton = findViewById(R.id.newGameButton);

        // מאזין לכפתור "Guess the Number"
        guessNumberButton.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                Intent intent = new Intent(MainActivity.this, GuessNumberActivity.class);
                startActivity(intent);
            }
        });

        // מאזין לכפתור "Fill Details (Capture Photo/Video)"
        fillDetailsButton.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                Intent intent = new Intent(MainActivity.this, FillDetailsActivity.class);
                startActivity(intent);
            }
        });

        // מאזין לכפתור "Math Calculator"
        calculatorButton.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                Intent intent = new Intent(MainActivity.this, MathCalculatorActivity.class);
                startActivity(intent);
            }
        });

        // מאזין לכפתור "New Game"
        newGameButton.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                Intent intent = new Intent(MainActivity.this, NewGameActivity.class);
                startActivity(intent);
            }
        });
    }
}

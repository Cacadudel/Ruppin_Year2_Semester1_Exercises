package com.example.endproject;

import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.TextView;

import androidx.appcompat.app.AppCompatActivity;

import java.util.Random;

public class GuessNumberActivity extends AppCompatActivity {

    private int targetNumber;
    private int range = 20;
    private EditText guessInput;
    private TextView rangeText;
    private TextView resultText;
    private Button checkButton;
    private Button resetButton;
    private Button backButton;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_guess_number);

        guessInput = findViewById(R.id.guessInput);
        rangeText = findViewById(R.id.rangeText);
        resultText = findViewById(R.id.resultText);
        checkButton = findViewById(R.id.checkButton);
        resetButton = findViewById(R.id.resetButton);
        backButton = findViewById(R.id.backButton);

        initializeGame();

        checkButton.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                String inputText = guessInput.getText().toString().trim();
                if (!inputText.isEmpty()) {
                    int guess = Integer.parseInt(inputText);
                    if (guess == targetNumber) {
                        resultText.setText("Correct!");
                        increaseDifficulty();
                    } else if (guess < targetNumber) {
                        resultText.setText("Higher! Try again.");
                    } else {
                        resultText.setText("Lower! Try again.");
                    }
                } else {
                    resultText.setText("Please enter a number.");
                }
            }
        });

        resetButton.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                initializeGame();
            }
        });

        backButton.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                Intent intent = new Intent(GuessNumberActivity.this, MainActivity.class);
                startActivity(intent);
                finish();
            }
        });
    }

    private void initializeGame() {
        range = 20;
        targetNumber = generateRandomNumber(range);
        rangeText.setText("Guess a number between 1 and " + range);
        resultText.setText("Result:");
        guessInput.setText("");
    }

    private void increaseDifficulty() {
        range += 10;
        targetNumber = generateRandomNumber(range);
        rangeText.setText("Guess a number between 1 and " + range);
    }

    private int generateRandomNumber(int maxRange) {
        Random random = new Random();
        return random.nextInt(maxRange) + 1;
    }
}

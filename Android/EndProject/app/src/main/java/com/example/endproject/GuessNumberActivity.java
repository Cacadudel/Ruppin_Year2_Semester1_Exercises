package com.example.endproject;

import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.TextView;
import android.widget.Toast;
import androidx.appcompat.app.AppCompatActivity;
import java.util.Random;

public class GuessNumberActivity extends AppCompatActivity {

    private int targetNumber;
    private int level = 1;
    private int maxRange = 10;
    private Random random;

    private EditText guessInput;
    private TextView resultText;
    private Button guessButton;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_guess_number);

        guessInput = findViewById(R.id.guessInput);
        resultText = findViewById(R.id.resultText);
        guessButton = findViewById(R.id.guessButton);

        random = new Random();
        generateNewNumber();

        guessButton.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                checkGuess();
            }
        });
    }

    private void generateNewNumber() {
        targetNumber = random.nextInt(maxRange) + 1;
    }

    private void checkGuess() {
        String input = guessInput.getText().toString();

        if (input.isEmpty()) {
            Toast.makeText(this, "Please enter a number", Toast.LENGTH_SHORT).show();
            return;
        }

        int guess = Integer.parseInt(input);

        if (guess == targetNumber) {
            resultText.setText("Correct! Moving to level " + (level + 1));
            level++;
            maxRange += 10; // כל רמה מוסיפה טווח גדול יותר
            generateNewNumber();
        } else if (guess < targetNumber) {
            resultText.setText("Too low! Try again.");
        } else {
            resultText.setText("Too high! Try again.");
        }

        guessInput.setText(""); // לנקות את השדה אחרי כל ניחוש
    }
}

package com.example.endproject;

import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.widget.AdapterView;
import android.widget.ArrayAdapter;
import android.widget.Button;
import android.widget.EditText;
import android.widget.ImageView;
import android.widget.Spinner;
import android.widget.TextView;
import android.widget.Toast;

import androidx.appcompat.app.AlertDialog;
import androidx.appcompat.app.AppCompatActivity;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.HashMap;
import java.util.HashSet;
import java.util.List;
import java.util.Map;
import java.util.Random;
import java.util.Set;

public class NewGameActivity extends AppCompatActivity {

    // UI Elements
    private Spinner categorySpinner;
    private Button newGameButton, guessButton, backButton;
    private ImageView hangmanImage;
    private TextView wordDisplay, usedLettersDisplay;
    private EditText letterInput;

    private Map<String, List<String>> categoryWords;
    private String currentWord = "";
    private char[] displayedWord;
    private Set<Character> usedLetters;
    private int wrongGuesses = 0;
    private final int MAX_WRONG_GUESSES = 6;
    private boolean gameActive = false;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_new_game);

        // Initialize UI elements
        categorySpinner = findViewById(R.id.categorySpinner);
        newGameButton = findViewById(R.id.newGameButton);
        guessButton = findViewById(R.id.guessButton);
        backButton = findViewById(R.id.backButton);
        hangmanImage = findViewById(R.id.hangmanImage);
        wordDisplay = findViewById(R.id.wordDisplay);
        usedLettersDisplay = findViewById(R.id.usedLettersDisplay);
        letterInput = findViewById(R.id.letterInput);

        setupCategoryWords();
        setupCategorySpinner();

        newGameButton.setOnClickListener(v -> startNewGame());

        guessButton.setOnClickListener(v -> {
            if (!gameActive) {
                Toast.makeText(NewGameActivity.this, "Please start a new game", Toast.LENGTH_SHORT).show();
                return;
            }

            String input = letterInput.getText().toString().toUpperCase();
            if (input.isEmpty()) {
                Toast.makeText(NewGameActivity.this, "Please enter a letter", Toast.LENGTH_SHORT).show();
                return;
            }

            char letter = input.charAt(0);
            processGuess(letter);
            letterInput.setText("");
        });

        backButton.setOnClickListener(v -> {
            Intent intent = new Intent(NewGameActivity.this, MainActivity.class);
            startActivity(intent);
            finish();
        });
    }
//יצירת קטגוריות ואיכלוסן
    private void setupCategoryWords() {
        categoryWords = new HashMap<>();

        // Add movies
        categoryWords.put("Movies", Arrays.asList(
                "THE GODFATHER",
                "STAR WARS",
                "JURASSIC PARK",
                "THE MATRIX",
                "TITANIC"
        ));

        // Add TV shows
        categoryWords.put("TV Shows", Arrays.asList(
                "GAME OF THRONES",
                "BREAKING BAD",
                "FRIENDS",
                "THE OFFICE",
                "STRANGER THINGS"
        ));

        // Add books
        categoryWords.put("Books", Arrays.asList(
                "HARRY POTTER",
                "THE LORD OF THE RINGS",
                "TO KILL A MOCKINGBIRD",
                "PRIDE AND PREJUDICE",
                "THE GREAT GATSBY"
        ));
    }
//הכנת קטגוריות בתוך הרשימה
    private void setupCategorySpinner() {
        List<String> categories = new ArrayList<>(categoryWords.keySet());
        ArrayAdapter<String> adapter = new ArrayAdapter<>(
                this, android.R.layout.simple_spinner_item, categories);
        adapter.setDropDownViewResource(android.R.layout.simple_spinner_dropdown_item);
        categorySpinner.setAdapter(adapter);
    }
//התחלת משחק חדש
    private void startNewGame() {
        gameActive = true;
        usedLetters = new HashSet<>();
        wrongGuesses = 0;

        // הגרלת שם מהקטגוריה
        String category = categorySpinner.getSelectedItem().toString();
        List<String> words = categoryWords.get(category);
        Random random = new Random();
        currentWord = words.get(random.nextInt(words.size()));

        //מחליף את האותיות בכוכביות להסתרת הפתרון
        displayedWord = new char[currentWord.length()];
        for (int i = 0; i < currentWord.length(); i++) {
            if (currentWord.charAt(i) == ' ') {
                displayedWord[i] = ' ';
            } else {
                displayedWord[i] = '*';
            }
        }

        updateWordDisplay();
        usedLettersDisplay.setText("");
        updateHangmanImage();

        Toast.makeText(this, "New game started! Category: " + category, Toast.LENGTH_SHORT).show();
    }
//תהליך הניחוש הכללי
    private void processGuess(char letter) {
        if (usedLetters.contains(letter)) {
            Toast.makeText(this, "You already used this letter", Toast.LENGTH_SHORT).show();
            return;
        }

        usedLetters.add(letter);
        updateUsedLetters();

        boolean letterFound = false;
        for (int i = 0; i < currentWord.length(); i++) {
            if (currentWord.charAt(i) == letter) {
                displayedWord[i] = letter;
                letterFound = true;
            }
        }

        if (letterFound) {
            updateWordDisplay();
            checkWinCondition();
        } else {
            wrongGuesses++;
            updateHangmanImage();
            checkLoseCondition();
        }
    }
//עדכון תצוגת המילה
    private void updateWordDisplay() {
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < displayedWord.length; i++) {
            sb.append(displayedWord[i]).append(" ");
        }
        wordDisplay.setText(sb.toString());
    }
//מציג את האותיות שהמשתמש ניחש. צריך לעצור אותו אם ינסה להשתמש שוב באחת
    private void updateUsedLetters() {
        StringBuilder sb = new StringBuilder();
        for (Character c : usedLetters) {
            sb.append(c).append(" ");
        }
        usedLettersDisplay.setText(sb.toString());
    }

    //שלבי הציור של האיש התלוי
    private void updateHangmanImage() {
        int resourceId;
        switch (wrongGuesses) {
            case 0:
                resourceId = R.drawable.hangman_stage0; //שלבי הציור של האיש התלוי
                break;
            case 1:
                resourceId = R.drawable.hangman_stage1;
                break;
            case 2:
                resourceId = R.drawable.hangman_stage2;
                break;
            case 3:
                resourceId = R.drawable.hangman_stage3;
                break;
            case 4:
                resourceId = R.drawable.hangman_stage4;
                break;
            case 5:
                resourceId = R.drawable.hangman_stage5;
                break;
            case 6:
                resourceId = R.drawable.hangman_stage6;
                break;
            default:
                resourceId = R.drawable.hangman_stage0;
        }
        hangmanImage.setImageResource(resourceId);
    }
//בדיקה  האם המשתמש השלים את המילה+ צריך להוסיף אופציה לניחוש
    private void checkWinCondition() {
        boolean wordCompleted = true;
        for (char c : displayedWord) {
            if (c == '*') {
                wordCompleted = false;
                break;
            }
        }

        if (wordCompleted) {
            gameActive = false;
            showGameEndDialog(true);
        }
    }
//הפעם בדיקה האם למשתמש נגמרו הנסיונות
    private void checkLoseCondition() {
        if (wrongGuesses >= MAX_WRONG_GUESSES) {
            gameActive = false;
            showGameEndDialog(false);
        }
    }
//פידבק ניצחון/הפסד
    private void showGameEndDialog(boolean won) {
        AlertDialog.Builder builder = new AlertDialog.Builder(this);
        builder.setTitle(won ? "Congratulations!" : "Game Over");

        String message = won
                ? "You guessed the word correctly!"
                : "You lost! The word was: " + currentWord;

        builder.setMessage(message);
        builder.setPositiveButton("New Game", (dialog, which) -> startNewGame());
        builder.setNegativeButton("Main Menu", (dialog, which) -> {
            Intent intent = new Intent(NewGameActivity.this, MainActivity.class);
            startActivity(intent);
            finish();
        });

        builder.setCancelable(false);
        builder.show();
    }
}
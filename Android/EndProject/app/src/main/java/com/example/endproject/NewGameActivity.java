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
    private Spinner categorySpinner, difficultySpinner;
    private Button newGameButton, guessButton, guessWordButton, backButton;
    private ImageView hangmanImage;
    private TextView wordDisplay, usedLettersDisplay;
    private EditText letterInput, wordGuessInput;

    // משתני משחק
    private Map<String, Map<String, List<String>>> categoryWordsByDifficulty; // מילון של קטגוריות עם מילון של רמות קושי ומילים
    private String currentWord = "";
    private String currentDifficulty = "";
    private char[] displayedWord;
    private Set<Character> usedLetters;
    private int wrongGuesses = 0;
    private final int MAX_WRONG_GUESSES = 6;
    private boolean gameActive = false;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_new_game);

        // החלת הUI
        categorySpinner = findViewById(R.id.categorySpinner);
        difficultySpinner = findViewById(R.id.difficultySpinner);
        newGameButton = findViewById(R.id.newGameButton);
        guessButton = findViewById(R.id.guessButton);
        guessWordButton = findViewById(R.id.guessWordButton);
        backButton = findViewById(R.id.backButton);
        hangmanImage = findViewById(R.id.hangmanImage);
        wordDisplay = findViewById(R.id.wordDisplay);
        usedLettersDisplay = findViewById(R.id.usedLettersDisplay);
        letterInput = findViewById(R.id.letterInput);
        wordGuessInput = findViewById(R.id.wordGuessInput);

        setupCategoryWords();
        setupCategorySpinner();
        setupDifficultySpinner();

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

        // מאזין לכפתור ניחוש המילה השלמה
        guessWordButton.setOnClickListener(v -> {
            if (!gameActive) {
                Toast.makeText(NewGameActivity.this, "Please start a new game", Toast.LENGTH_SHORT).show();
                return;
            }

            String guessedWord = wordGuessInput.getText().toString().trim().toUpperCase();
            if (guessedWord.isEmpty()) {
                Toast.makeText(NewGameActivity.this, "Please enter a word", Toast.LENGTH_SHORT).show();
                return;
            }

            processWordGuess(guessedWord);
            wordGuessInput.setText("");
        });

        backButton.setOnClickListener(v -> {
            Intent intent = new Intent(NewGameActivity.this, MainActivity.class);
            startActivity(intent);
            finish();
        });
    }

    //יצירת קטגוריות ואיכלוסן על פי רמות קושי
    private void setupCategoryWords() {
        categoryWordsByDifficulty = new HashMap<>();

        // יצירת מילון לקטגוריית סרטים
        Map<String, List<String>> moviesByDifficulty = new HashMap<>();
        // סרטים ברמה קלה (4-5 אותיות)
        moviesByDifficulty.put("Easy", Arrays.asList(
                "JAWS", "CARS", "STAR", "DUNE", "LION"
        ));
        // סרטים ברמה בינונית (6-8 אותיות)
        moviesByDifficulty.put("Medium", Arrays.asList(
                "TITANIC", "BATMAN", "MATRIX", "FROZEN", "JOKER"
        ));
        // סרטים ברמה קשה (9+ אותיות או מילים מרובות)
        moviesByDifficulty.put("Hard", Arrays.asList(
                "THE GODFATHER",
                "JURASSIC PARK",
                "THE DARK KNIGHT",
                "FORREST GUMP",
                "INCEPTION"
        ));
        categoryWordsByDifficulty.put("Movies", moviesByDifficulty);

        // יצירת מילון לקטגוריית סדרות טלוויזיה
        Map<String, List<String>> showsByDifficulty = new HashMap<>();
        // סדרות ברמה קלה
        showsByDifficulty.put("Easy", Arrays.asList(
                "LOST", "GLEE", "POSE", "MONK", "ROME"
        ));
        // סדרות ברמה בינונית
        showsByDifficulty.put("Medium", Arrays.asList(
                "FRIENDS", "SCRUBS", "HEROES", "DEXTER", "THE BOYS"
        ));
        // סדרות ברמה קשה
        showsByDifficulty.put("Hard", Arrays.asList(
                "GAME OF THRONES",
                "BREAKING BAD",
                "THE WALKING DEAD",
                "STRANGER THINGS",
                "THE CROWN"
        ));
        categoryWordsByDifficulty.put("TV Shows", showsByDifficulty);

        // יצירת מילון לקטגוריית ספרים
        Map<String, List<String>> booksByDifficulty = new HashMap<>();
        // ספרים ברמה קלה
        booksByDifficulty.put("Easy", Arrays.asList(
                "IT", "DUNE", "JAWS", "ROOM", "GONE"
        ));
        // ספרים ברמה בינונית
        booksByDifficulty.put("Medium", Arrays.asList(
                "DRACULA", "MATILDA", "BELOVED", "REBECCA", "CARRIE"
        ));
        // ספרים ברמה קשה
        booksByDifficulty.put("Hard", Arrays.asList(
                "PRIDE AND PREJUDICE",
                "TO KILL A MOCKINGBIRD",
                "THE GREAT GATSBY",
                "THE LORD OF THE RINGS",
                "CRIME AND PUNISHMENT"
        ));
        categoryWordsByDifficulty.put("Books", booksByDifficulty);
    }

    //הכנת קטגוריות בתוך הרשימה
    private void setupCategorySpinner() {
        List<String> categories = new ArrayList<>(categoryWordsByDifficulty.keySet());
        ArrayAdapter<String> adapter = new ArrayAdapter<>(
                this, android.R.layout.simple_spinner_item, categories);
        adapter.setDropDownViewResource(android.R.layout.simple_spinner_dropdown_item);
        categorySpinner.setAdapter(adapter);
    }

    //הכנת רמות קושי בתוך הרשימה
    private void setupDifficultySpinner() {
        List<String> difficulties = Arrays.asList("Easy", "Medium", "Hard");
        ArrayAdapter<String> adapter = new ArrayAdapter<>(
                this, android.R.layout.simple_spinner_item, difficulties);
        adapter.setDropDownViewResource(android.R.layout.simple_spinner_dropdown_item);
        difficultySpinner.setAdapter(adapter);
    }

    //התחלת משחק חדש
    private void startNewGame() {
        gameActive = true;
        usedLetters = new HashSet<>();
        wrongGuesses = 0;

        // קבלת קטגוריה ורמת קושי נבחרת
        String category = categorySpinner.getSelectedItem().toString();
        currentDifficulty = difficultySpinner.getSelectedItem().toString();

        // קבלת רשימת המילים המתאימה לקטגוריה ולרמת הקושי
        Map<String, List<String>> difficultyWords = categoryWordsByDifficulty.get(category);
        List<String> words = difficultyWords.get(currentDifficulty);

        // הגרלת מילה אקראית מהרשימה
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

        Toast.makeText(this, "New game started! Category: " + category + ", Difficulty: " + currentDifficulty, Toast.LENGTH_SHORT).show();
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

    // תהליך הניחוש למילה שלמה
    private void processWordGuess(String guessedWord) {
        if (guessedWord.equals(currentWord)) {
            // ניחוש נכון - חשיפת כל האותיות
            for (int i = 0; i < currentWord.length(); i++) {
                displayedWord[i] = currentWord.charAt(i);
            }
            updateWordDisplay();
            gameActive = false;
            showGameEndDialog(true);
        } else {
            // ניחוש שגוי - המשחק נגמר בהפסד
            wrongGuesses = MAX_WRONG_GUESSES;
            updateHangmanImage();
            gameActive = false;
            showGameEndDialog(false);
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

    //בדיקה האם המשתמש השלים את המילה
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
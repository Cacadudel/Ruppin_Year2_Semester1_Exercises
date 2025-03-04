package com.example.endproject;

import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.TextView;

import androidx.appcompat.app.AppCompatActivity;

public class MathCalculatorActivity extends AppCompatActivity {

    private EditText number1, number2;
    private TextView resultText;
    private char selectedOperation; // שמירת הפעולה שנבחרה

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_math_calculator);

        // קישור בין הרכיבים במסך למשתנים
        number1 = findViewById(R.id.number1);
        number2 = findViewById(R.id.number2);
        resultText = findViewById(R.id.resultText);

        Button addButton = findViewById(R.id.addButton);
        Button subtractButton = findViewById(R.id.subtractButton);
        Button multiplyButton = findViewById(R.id.multiplyButton);
        Button divideButton = findViewById(R.id.divideButton);
        Button equalButton = findViewById(R.id.equalButton);
        Button backButton = findViewById(R.id.backButton);

        // מאזינים ללחצני הפעולות ושמירת הפעולה שנבחרה
        addButton.setOnClickListener(v -> setOperation('+'));
        subtractButton.setOnClickListener(v -> setOperation('-'));
        multiplyButton.setOnClickListener(v -> setOperation('*'));
        divideButton.setOnClickListener(v -> setOperation('/'));

        // מאזין ללחצן "=" לביצוע החישוב והצגת התוצאה
        equalButton.setOnClickListener(v -> calculateResult());

        // מאזין ללחצן "Back" לחזרה לעמוד הראשי
        backButton.setOnClickListener(v -> {
            Intent intent = new Intent(MathCalculatorActivity.this, MainActivity.class);
            startActivity(intent);
            finish();
        });
    }

    // שמירת הפעולה שנבחרה בלבד, ללא חישוב מידי
    private void setOperation(char operation) {
        selectedOperation = operation;
        resultText.setText("Operation set: " + operation);
    }

    // ביצוע החישוב רק כאשר לוחצים על "="
    private void calculateResult() {
        try {
            double num1 = Double.parseDouble(number1.getText().toString());
            double num2 = Double.parseDouble(number2.getText().toString());
            double result = 0;

            switch (selectedOperation) {
                case '+':
                    result = num1 + num2;
                    break;
                case '-':
                    result = num1 - num2;
                    break;
                case '*':
                    result = num1 * num2;
                    break;
                case '/':
                    if (num2 != 0) {
                        result = num1 / num2;
                    } else {
                        resultText.setText("Cannot divide by zero!");
                        return;
                    }
                    break;
                default:
                    resultText.setText("Select an operation first!");
                    return;
            }
            resultText.setText("Result: " + result);

        } catch (NumberFormatException e) {
            resultText.setText("Invalid input!");
        }
    }
}

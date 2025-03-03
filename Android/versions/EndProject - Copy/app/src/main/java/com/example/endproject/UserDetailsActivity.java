package com.example.endproject;

import android.content.Intent;
import android.graphics.Bitmap;
import android.graphics.BitmapFactory;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.ImageView;
import android.widget.TextView;
import android.widget.Toast;

import androidx.appcompat.app.AppCompatActivity;

import java.io.File;

public class UserDetailsActivity extends AppCompatActivity {

    private ImageView userImage;
    private TextView userFullName, userIdDisplay, userEmailDisplay;
    private Button backToMainButton;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_user_details);

        userImage = findViewById(R.id.userImage);
        userFullName = findViewById(R.id.userFullName);
        userIdDisplay = findViewById(R.id.userIdDisplay);
        userEmailDisplay = findViewById(R.id.userEmailDisplay);
        backToMainButton = findViewById(R.id.backToMainButton);

        Intent intent = getIntent();
        if (intent != null) {
            String firstName = intent.getStringExtra("firstName");
            String lastName = intent.getStringExtra("lastName");
            String id = intent.getStringExtra("id");
            String email = intent.getStringExtra("email");
            String imagePath = intent.getStringExtra("imagePath");

            User user = new User(firstName, lastName, id, email, imagePath);

            displayUserInfo(user);
        }

        backToMainButton.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                Intent intent = new Intent(UserDetailsActivity.this, MainActivity.class);
                startActivity(intent);
                finish();
            }
        });
    }

    private void displayUserInfo(User user) {
        userFullName.setText(user.getFirstName() + " " + user.getLastName());
        userIdDisplay.setText("ID: " + user.getId());
        userEmailDisplay.setText("Email: " + user.getEmail());

        loadUserImage(user.getImagePath());
    }

    private void loadUserImage(String imageName) {
        try {
            File internalDir = new File(getFilesDir(), "user_images");

            File imageFile = new File(internalDir, imageName);

            if (imageFile.exists()) {
                Bitmap bitmap = BitmapFactory.decodeFile(imageFile.getAbsolutePath());

                userImage.setImageBitmap(bitmap);
            } else {
                Toast.makeText(this, "Image not found", Toast.LENGTH_SHORT).show();
            }
        } catch (Exception e) {
            e.printStackTrace();
            Toast.makeText(this, "Error loading image", Toast.LENGTH_SHORT).show();
        }
    }
}
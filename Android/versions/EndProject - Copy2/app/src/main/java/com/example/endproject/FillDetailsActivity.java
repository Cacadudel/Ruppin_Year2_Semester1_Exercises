package com.example.endproject;

import android.Manifest;
import android.content.Intent;
import android.content.pm.PackageManager;
import android.graphics.Bitmap;
import android.net.Uri;
import android.os.Bundle;
import android.os.Environment;
import android.provider.MediaStore;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.ImageView;
import android.widget.Toast;

import androidx.annotation.NonNull;
import androidx.appcompat.app.AppCompatActivity;
import androidx.core.app.ActivityCompat;
import androidx.core.content.ContextCompat;
import androidx.core.content.FileProvider;

import java.io.File;
import java.io.FileOutputStream;
import java.io.IOException;
import java.text.SimpleDateFormat;
import java.util.Date;
import java.util.Locale;

public class FillDetailsActivity extends AppCompatActivity {

    private static final int CAMERA_PERMISSION_CODE = 100;
    private static final int CAMERA_REQUEST_CODE = 101;

    private EditText firstNameInput, lastNameInput, idInput, emailInput;
    private ImageView imagePreview;
    private Button captureButton, submitButton, backButton;

    private String currentPhotoPath = "";
    private Uri photoUri;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_fill_details);

        firstNameInput = findViewById(R.id.firstName);
        lastNameInput = findViewById(R.id.lastName);
        idInput = findViewById(R.id.userId);
        emailInput = findViewById(R.id.userEmail);
        imagePreview = findViewById(R.id.imagePreview);
        captureButton = findViewById(R.id.captureButton);
        submitButton = findViewById(R.id.submitButton);
        backButton = findViewById(R.id.backButton);

        captureButton.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                askCameraPermission();
            }
        });

        submitButton.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                validateAndSubmit();
            }
        });

        backButton.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                Intent intent = new Intent(FillDetailsActivity.this, MainActivity.class);
                startActivity(intent);
                finish();
            }
        });
    }

    private void askCameraPermission() {
        if (ContextCompat.checkSelfPermission(this, Manifest.permission.CAMERA) != PackageManager.PERMISSION_GRANTED) {
            ActivityCompat.requestPermissions(this, new String[]{Manifest.permission.CAMERA}, CAMERA_PERMISSION_CODE);
        } else {
            openCamera();
        }
    }

    @Override
    public void onRequestPermissionsResult(int requestCode, @NonNull String[] permissions, @NonNull int[] grantResults) {
        super.onRequestPermissionsResult(requestCode, permissions, grantResults);
        if (requestCode == CAMERA_PERMISSION_CODE) {
            if (grantResults.length > 0 && grantResults[0] == PackageManager.PERMISSION_GRANTED) {
                openCamera();
            } else {
                Toast.makeText(this, "Camera permission is required to capture photo", Toast.LENGTH_SHORT).show();
            }
        }
    }

    private void openCamera() {
        Intent cameraIntent = new Intent(MediaStore.ACTION_IMAGE_CAPTURE);

        File photoFile = null;
        try {
            photoFile = createImageFile();
        } catch (IOException ex) {
            Toast.makeText(this, "Error creating image file", Toast.LENGTH_SHORT).show();
        }

        if (photoFile != null) {
            photoUri = FileProvider.getUriForFile(this,
                    "com.example.endproject.fileprovider",
                    photoFile);
            cameraIntent.putExtra(MediaStore.EXTRA_OUTPUT, photoUri);
            startActivityForResult(cameraIntent, CAMERA_REQUEST_CODE);
        }
    }

    private File createImageFile() throws IOException {
        String timeStamp = new SimpleDateFormat("yyyyMMdd_HHmmss", Locale.getDefault()).format(new Date());
        String imageFileName = "JPEG_" + timeStamp + "_";
        File storageDir = getExternalFilesDir(Environment.DIRECTORY_PICTURES);
        File image = File.createTempFile(
                imageFileName,  /* שם הקובץ */
                ".jpg",   /* סוג קובץ או סיומת קובץ בךהכךעלרכרלך */
                storageDir      /* התיקייה */
        );

        currentPhotoPath = image.getAbsolutePath();
        return image;
    }

    @Override
    protected void onActivityResult(int requestCode, int resultCode, Intent data) {
        super.onActivityResult(requestCode, resultCode, data);
        if (requestCode == CAMERA_REQUEST_CODE && resultCode == RESULT_OK) {
            imagePreview.setImageURI(photoUri);
        }
    }

    private void validateAndSubmit() {
        String firstName = firstNameInput.getText().toString().trim();
        String lastName = lastNameInput.getText().toString().trim();
        String id = idInput.getText().toString().trim();
        String email = emailInput.getText().toString().trim();

        if (firstName.isEmpty() || lastName.isEmpty() || id.isEmpty() || email.isEmpty()) {
            Toast.makeText(this, "Please fill in all fields", Toast.LENGTH_SHORT).show();
            return;
        }

        if (currentPhotoPath.isEmpty()) {
            Toast.makeText(this, "Please capture a photo", Toast.LENGTH_SHORT).show();
            return;
        }

        User user = new User(firstName, lastName, id, email, currentPhotoPath);

        String userImageName = firstName + "_" + lastName + ".jpg";
        saveImageWithUserName(userImageName);

        Intent intent = new Intent(FillDetailsActivity.this, UserDetailsActivity.class);
        intent.putExtra("firstName", user.getFirstName());
        intent.putExtra("lastName", user.getLastName());
        intent.putExtra("id", user.getId());
        intent.putExtra("email", user.getEmail());
        intent.putExtra("imagePath", userImageName);
        startActivity(intent);
    }

    private void saveImageWithUserName(String userImageName) {
        try {
            // Get the bitmap from the current photo path
            Bitmap bitmap = MediaStore.Images.Media.getBitmap(getContentResolver(), photoUri);

            // Define where to save the image in the app's internal storage
            File internalDir = new File(getFilesDir(), "user_images");
            if (!internalDir.exists()) {
                internalDir.mkdirs();
            }

            File destFile = new File(internalDir, userImageName);

            FileOutputStream fos = new FileOutputStream(destFile);
            bitmap.compress(Bitmap.CompressFormat.JPEG, 90, fos);
            fos.flush();
            fos.close();

        } catch (IOException e) {
            e.printStackTrace();
            Toast.makeText(this, "Error saving image", Toast.LENGTH_SHORT).show();
        }
    }
}
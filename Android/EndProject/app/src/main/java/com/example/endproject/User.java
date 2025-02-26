package com.example.endproject;

public class User {
    private String firstName;
    private String lastName;
    private String id;
    private String email;
    private String imagePath;

    // Constructor, getters and setters
    public User(String firstName, String lastName, String id, String email, String imagePath) {
        this.firstName = firstName;
        this.lastName = lastName;
        this.id = id;
        this.email = email;
        this.imagePath = imagePath;
    }


    public String getFirstName() {
        return firstName;
    }

    public String getLastName() {
        return lastName;
    }

    public String getId() {
        return id;
    }

    public String getEmail() {
        return email;
    }

    public String getImagePath() {
        return imagePath;
    }

    public void setFirstName(String firstName){
        this.firstName = firstName;
    }

    public void setLastName(String lastName)
    {
        this.lastName = lastName;
    }

    public void setId(String id)
    {
        this.id = id;
    }

    public void setEmail(String email)
    {
        this.email = email;
    }

    public void setImagePath(String imagePath)
    {
        this.imagePath = imagePath;
    }
}

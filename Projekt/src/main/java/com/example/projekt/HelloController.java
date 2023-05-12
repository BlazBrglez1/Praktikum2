package com.example.projekt;

import javafx.fxml.FXML;
import javafx.scene.control.Label;
import javafx.stage.FileChooser;
import javafx.stage.FileChooser;
import javafx.stage.FileChooser.ExtensionFilter;

import java.io.File;

public class HelloController {
    @FXML
    private Label welcomeText;

    @FXML
    protected void onHelloButtonClick() {
        welcomeText.setText("Welcome to JavaFX Application!");
        // Create a file chooser
        FileChooser fileChooser = new FileChooser();
        fileChooser.setTitle("Select PDF File");

        // Set filters to only allow PDF files
        ExtensionFilter pdfFilter = new ExtensionFilter("PDF Files (*.pdf)", "*.pdf");
        fileChooser.getExtensionFilters().add(pdfFilter);

        // Show the file chooser dialog
        File selectedFile = fileChooser.showOpenDialog(welcomeText.getScene().getWindow());

        // Check if a file was selected
        if (selectedFile != null) {


            System.out.println("Selected PDF file: " + selectedFile.getAbsolutePath());
        }
    }





}


module com.example.projekt {
    requires javafx.controls;
    requires javafx.fxml;

    requires com.dlsc.formsfx;
    requires org.kordamp.bootstrapfx.core;

    opens com.example.projekt to javafx.fxml;
    exports com.example.projekt;
}
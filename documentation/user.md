<?php
require_once("../config/database.php");

class User {
    public static function create($name, $age, $email) {
        $db = Database::getInstance()->getConnection();
        $stmt = $db->prepare("INSERT INTO users (nom, age, email) VALUES (?, ?, ?)");
        $stmt->bind_param("sis", $name, $age, $email);
        $stmt->execute();
        return $db->insert_id;
    }
}
?>

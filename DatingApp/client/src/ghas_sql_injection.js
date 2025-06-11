import express from "express";
import mysql from "mysql";

const app = express();
const connection = mysql.createConnection({
  host: "localhost",
  user: "root",
  password: "",
  database: "test",
});

app.get("/user", (req, res) => {
  const userId = req.query.id;
  // ❗ Vulnerable SQL injection (unsanitized input)
  const query = "SELECT * FROM users WHERE id = '" + userId + "'";
  connection.query(query, (err, result) => {
    if (err) throw err;
    res.send(result);
  });
});

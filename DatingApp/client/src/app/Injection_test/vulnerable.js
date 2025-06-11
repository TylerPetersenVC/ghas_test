const express = require("express");
const app = express();

app.get("/user", function (req, res) {
  const userId = req.query.id;
  const query = "SELECT * FROM users WHERE id = '" + userId + "'";
  db.query(query, function (err, result) {
    if (err) throw err;
    res.send(result);
  });
});

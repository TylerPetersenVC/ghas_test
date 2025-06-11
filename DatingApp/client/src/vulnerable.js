const express = require("express");
const app = express();

app.get("/search", (req, res) => {
  const userInput = req.query.q;
  const html = "<div>" + userInput + "</div>"; // XSS source
  res.send(html); // XSS sink
});

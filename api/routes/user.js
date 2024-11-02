const express = require('express');
const { authenticate } = require('../middlewares/auth');

const router = express.Router();

router.get('/user', authenticate, (req, res) => {
  res.json({ message: `Welcome ${req.user.Nickname}` });
});

module.exports = router;
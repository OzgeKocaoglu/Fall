const jwt = require('jsonwebtoken');
const bcrypt = require('bcrypt');
const User = require('../models/user');

const key = "f8576fd41fbda5641c6ee6b46778a82e3bca8ac55e9d10a2563f0316e88b8d40";

// Register a new user
const register = async (req, res, next) => {
    const { Nickname, Email, Password, Level, HighScore } = req.body;
  
    try {
      const user = new User({ Nickname, Email, Password, Level, HighScore });
      await user.save();
      res.json({ message: 'Registration successful' });
    } catch (error) {
      next(error);
    }
  };

  // Login with an existing user
const login = async (req, res, next) => {
    const { Nickname, Password} = req.body;
  
    try {
      const user = await User.findOne({ Nickname });
      if (!user) {
        return res.status(404).json({ message: 'User not found' });
      }
  
    // console.log(user.Password);
    // const hashedPassword = await bcrypt.hash(req.body.Password, 10);
      const passwordMatch = await user.comparePassword(req.body.Password);

      if (!passwordMatch) {
        return res.status(401).json({ message: 'Incorrect password' });
      }
  
      const token = jwt.sign({ userId: user._id }, key, {
        expiresIn: '1 hour'
      });
      res.json({ token });
    } catch (error) {
      next(error);
    }
  };

  module.exports = { register, login };
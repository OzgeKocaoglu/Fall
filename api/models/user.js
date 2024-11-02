const mongoose = require('mongoose');
const bcrypt = require('bcrypt');

const userSchema = mongoose.Schema({
    Nickname: {
        required: true,
        type: String
    },
    Email: {
        required: true,
        type: String
    },
    Password : {
        required: true,
        type: String
    },
    Level: {
        required: true,
        type: Number
    },
    HighScore : {
        required : true,
        type: Number
    }
});

userSchema.pre('save', async function (next) {
    const user = this;
    if (!user.isModified('Password')) return next();
  
    try {
    //   user.Password = await bcrypt.hash(user.Password, 10);
      next();
    } catch (error) {
      return next(error);
    }
  });
  
// Compare the given password with the hashed password in the database
userSchema.methods.comparePassword = async function (password) {
    return password == this.Password;
};
  

module.exports = mongoose.model('User', userSchema);
require('dotenv').config;
const mongoose = require('mongoose');

const uri = "mongodb+srv://ozgekocaoglu6:Xgus26XuHYxTMgt5@cluster.rsiv3.mongodb.net/";

const connectDB = async () => {
    try {
      await mongoose.connect(uri, {

      });
      console.log('Connected to MongoDB');
    } catch (error) {
      console.log('Error connecting to MongoDB:', error);
    }
  };
  
  module.exports = connectDB;
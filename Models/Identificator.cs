using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using FaceRecognitionDotNet;
using System.Drawing;
using IntershipProject.Models;
using Microsoft.AspNetCore.Identity;
using FaceImage = FaceRecognitionDotNet.Image;

namespace Webcam.Models
{
    public class Identificator
    {
        private readonly FaceRecognition _fr;
        private readonly UserManager<AppUser> _userManager;


        public Identificator(UserManager<AppUser> userManager)
        {
            string directory = Directory.GetCurrentDirectory() + @"\face_models";
            _fr = FaceRecognition.Create(directory);
            _userManager = userManager;
        }

        private Bitmap Base64ToImage(string base64String)
        {
            base64String = base64String.Split(',')[1];
            byte[] imageData = Convert.FromBase64String(base64String);
            Bitmap bmp;
            using (var ms = new MemoryStream(imageData))
            {
                bmp = new Bitmap(ms);
            }
            return bmp;
        }

        public Result ComparePic(string imagePathA, string imagePathB)
        {
            FaceImage imageA = FaceRecognition.LoadImage(Base64ToImage(imagePathA));
            FaceImage imageB = FaceRecognition.LoadImage(Base64ToImage(imagePathB));

            IEnumerable<Location> locationsA = _fr.FaceLocations(imageA);
            IEnumerable<Location> locationsB = _fr.FaceLocations(imageB);

            IEnumerable<FaceEncoding> encodingA = _fr.FaceEncodings(imageA, locationsA);
            IEnumerable<FaceEncoding> encodingB = _fr.FaceEncodings(imageB, locationsB);

            if (encodingA.Count() == 0) { return Result.BasePictureBroken; }
                //throw new Exception("Base Picture is Broken");
            if (encodingB.Count() == 0) { return Result.NoFace; }
                //throw new Exception("Error While Face Recognition. Take a new Picture, please");

            const double tolerance = 0.6d;
            return FaceRecognition.CompareFace(encodingA.First(), encodingB.First(), tolerance) ? Result.Success : Result.Fail;
        }
    }
}

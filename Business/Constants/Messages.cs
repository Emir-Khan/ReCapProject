using Core.Entities.Concrete;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        
        public static string CarAdded = "Araba eklendi";
        public static string CarUpdated = "Araba güncellendi";
        public static string CarDeleted = "Araba silindi";

        public static string ColorAdded = "Renk eklendi";
        public static string ColorUpdated = "Renk güncellendi";
        public static string ColorDeleted = "Renk silindi";

        public static string BrandAdded = "Marka eklendi";
        public static string BrandUpdated = "Marka güncellendi";
        public static string BrandDeleted = "Marka silindi";

        public static string UserAdded = "Kullanıcı eklendi";
        public static string UserUpdated = "Kullanıcı güncellendi";
        public static string UserDeleted = "Kullanıcı silindi";

        public static string CustomerAdded = "Müşteri eklendi";
        public static string CustomerUpdated = "Müşteri güncellendi";
        public static string CustomerDeleted = "Müşteri silindi";

        public static string RentalAdded = "Kiralama eklendi";
        public static string RentalUptated = "Kiralama güncellendi";
        public static string Rentaldeleted = "Kiralama silindi";

        public static string RentalDenied = "Kiralama geçersiz";

        public static string CarImageAdded = "Araba resmi eklendi";
        public static string CarImageUpdated = "Araba resmi güncellendi";
        public static string CarImageDeleted = "Araba resmi silindi";
        public static string ImageNotFound = "Resim Bulunamadı";

        public static string CarNameAlreadyExists = "Araba ismi mevcut";
        public static string UserNotFound = "Email bulunamadı";
        public static string PasswordError = "Şifre hatalı";
        public static string SuccessfulLogin = "Giriş başarılı";
        public static string UserAlreadyExists = "Bu kullanıcı zaten mevcut";
        public static string UserRegistered = "Kayıt başarılı";
        public static string AccessTokenCreated ="JWT Created";
        public static string AuthorizationDenied = "Reddedildi";
        public static string RentalNotAvailable ="Seçtiğiniz tarihler arasında araç zaten kiralı";
        public static string RentalDateError="Seçtiğiniz tarihleri kontrol ediniz";
        public static string CardAdded ="Araba Eklendi";
        public static string CardDeleted ="Araba Silindi";

        public static string RentalCanNotFind = "Kullanıcı Henüz Araç kiralamamış";
    }
}

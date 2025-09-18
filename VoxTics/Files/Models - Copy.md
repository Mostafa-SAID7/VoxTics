VoxTics/Models/Entities/
 ├─ BaseEntity.cs                
 ├─ Actor.cs
 ├─ Movie.cs
 ├─ MovieActor.cs             # علاقة فيلم ↔ ممثل
 ├─ MovieImage.cs             # صور الأفلام (استبدل MovieImg)
 ├─ Category.cs
 ├─ Cinema.cs
 ├─ Hall.cs
 ├─ Seat.cs
 ├─ Showtime.cs
 ├─ Booking.cs
 ├─ BookingSeat.cs
 ├─ Payment.cs
 ├─ CartItem.cs               # يكفي بدون Cart
 ├─ WishlistItem.cs           # بديل Watchlist/WatchlistItem/UserMovieWatchlist
 ├─ Notification.cs
 └─ SocialMediaLink.cs        # فقط لو هتديره من لوحة التحكم
	Review.cs (اختياري)  # لو هتضيف تقييمات

VoxTics/Models/Identity/
 ├─ ApplicationUser.cs          # المستخدم مع خصائص إضافية
 ├─ ApplicationRole.cs          # enum للأدوار
 ├─ ApplicationRoleConfig.cs    # (اختياري) تكوين أولي للأدوار الافتراضية
 ├─ UserProfile.cs              # ملف شخصي للمستخدم (فصل البيانات القابلة للتغيير)
 ├─ UserClaim.cs                # تخصيص Claims
 ├─ UserToken.cs                # تخصيص Tokens
 └─ OtpUser.cs                  # أكواد التحقق OTP

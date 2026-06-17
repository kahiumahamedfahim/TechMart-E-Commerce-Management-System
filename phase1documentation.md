┌─────────────┐
│    User     │
├─────────────┤
│ Id          │
│ UserId      │
│ Email       │
└──────┬──────┘
       │
       │ One
       │
       ▼
Many
┌──────────────────────┐
│ EmailVerificationCode│
├──────────────────────┤
│ Id                   │
│ UserId (FK)          │
│ VerificationCode     │
│ ExpiryTime           │
│ IsUsed               │
└──────────────────────┘


EmailSettings হলো Configuration Model।

Configure<EmailSettings>() JSON Data কে
EmailSettings Object-এ Convert করে।

ASP.NET Core সেই Object-কে
IOptions<EmailSettings> Wrapper-এর ভিতরে রেখে
DI Container-এ Register করে।

Constructor-এ IOptions<EmailSettings> পাই।

options.Value দিয়ে Wrapper-এর ভিতরের
আসল EmailSettings Object বের করি।
namespace ImgBoard.Dal.Migrations.Production
{
    using ImgBoard.Dal.Models.Main;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class ProdConfiguration : DbMigrationsConfiguration<ImgBoard.Dal.Context.EndObjects.ImgBoardContext>
    {
        public ProdConfiguration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"Migrations\Production";
        }

        protected override void Seed(ImgBoard.Dal.Context.EndObjects.ImgBoardContext context)
        {
            #region Categories
            var Category1 = new DbCategory
            {
                Id = 1,
                Title = "Nature"
            };
            var Category2 = new DbCategory
            {
                Id = 2,
                Title = "Technology"
            };
            var Category3 = new DbCategory
            {
                Id = 3,
                Title = "Space"
            };
            #endregion

            #region Users
            var user1 = new DbUser
            {
                Id = 1,
                Login = "a",
                Password = "a",
                UserName = "User A"
            };
            var user2 = new DbUser
            {
                Id = 2,
                Login = "b",
                Password = "b",
                UserName = "User B"
            };
            #endregion

            #region Images
            // no cat
            var image1 = new DbImage
            {
                Id = 1,
                IdCategory = null,
                IdUploader = 1,
                Name = null,
                Description = null,
                FileId = new Guid("1be96b96ce194f1ab2bc54db0c269df9"),
                FileExtension = "png"
            };
            var image2 = new DbImage
            {
                Id = 2,
                IdCategory = null,
                IdUploader = 1,
                Name = null,
                Description = null,
                FileId = new Guid("0c85e4d2fa1443fbaabaa069aa7879f3"),
                FileExtension = "png"
            };
            var image3 = new DbImage
            {
                Id = 3,
                IdCategory = null,
                IdUploader = 1,
                Name = "Some name",
                Description = null,
                FileId = new Guid("e7f2cd1471bc4a3ab64ad5dfa4774b64"),
                FileExtension = "png"
            };
            var image4 = new DbImage
            {
                Id = 4,
                IdCategory = null,
                IdUploader = 2,
                Name = "Some cool name",
                Description = null,
                FileId = new Guid("e2eb8ffbfc9542c3911ab53c8dbd1da9"),
                FileExtension = "png"
            };
            var image5 = new DbImage
            {
                Id = 5,
                IdCategory = null,
                IdUploader = 2,
                Name = null,
                Description = "Some description",
                FileId = new Guid("5d02a31ac3b74a219c72750bcbe683bd"),
                FileExtension = "png"
            };
            // cat 1
            var image6 = new DbImage
            {
                Id = 6,
                IdCategory = 1,
                IdUploader = 1,
                Name = "Something",
                Description = "Something cool",
                FileId = new Guid("0974ed5725964ad0b71c65314c79bff3"),
                FileExtension = "png"
            };
            var image7 = new DbImage
            {
                Id = 7,
                IdCategory = 1,
                IdUploader = 1,
                Name = "Blabla",
                Description = null,
                FileId = new Guid("7fdb4ad242124b07b7c16b772066606f"),
                FileExtension = "png"
            };
            var image8 = new DbImage
            {
                Id = 8,
                IdCategory = 1,
                IdUploader = 1,
                Name = "Nono",
                Description = "Yolo",
                FileId = new Guid("1697cdbe47134c64a802446724594b5b"),
                FileExtension = "png"
            };
            var image9 = new DbImage
            {
                Id = 9,
                IdCategory = 1,
                IdUploader = 1,
                Name = null,
                Description = "Super cool",
                FileId = new Guid("d8e7e1ad6810461ca5e888215eee456a"),
                FileExtension = "png"
            };
            var image10 = new DbImage
            {
                Id = 10,
                IdCategory = 1,
                IdUploader = 1,
                Name = "Ahaha",
                Description = null,
                FileId = new Guid("2749a186cda74da9a090fad2db1aa1ed"),
                FileExtension = "png"
            };

            var image11 = new DbImage
            {
                Id = 11,
                IdCategory = 1,
                IdUploader = 2,
                Name = "Not cool",
                Description = "Yes",
                FileId = new Guid("0bd69a48caa4407899283251a2c7aa62"),
                FileExtension = "png"
            };
            var image12 = new DbImage
            {
                Id = 12,
                IdCategory = 1,
                IdUploader = 2,
                Name = "Meh",
                Description = null,
                FileId = new Guid("d68a9e301fc64f5c93a095d624617be7"),
                FileExtension = "jpg"
            };
            var image13 = new DbImage
            {
                Id = 13,
                IdCategory = 1,
                IdUploader = 2,
                Name = "Gah",
                Description = null,
                FileId = new Guid("45c6107002384fad81649c027ddde337"),
                FileExtension = "png"
            };
            var image14 = new DbImage
            {
                Id = 14,
                IdCategory = 1,
                IdUploader = 2,
                Name = "Ahaha",
                Description = "Super",
                FileId = new Guid("fefcfdf503b04350a5c0ccd6e41c0088"),
                FileExtension = "png"
            };
            var image15 = new DbImage
            {
                Id = 15,
                IdCategory = 1,
                IdUploader = 2,
                Name = null,
                Description = null,
                FileId = new Guid("3e6c20cc95c34c8cabb436453a3fa476"),
                FileExtension = "png"
            };
            var image16 = new DbImage
            {
                Id = 16,
                IdCategory = 1,
                IdUploader = 2,
                Name = null,
                Description = "Ouah",
                FileId = new Guid("8855611b7bff43c1a8c5e3d42c2ae0c7"),
                FileExtension = "png"
            };
            var image17 = new DbImage
            {
                Id = 17,
                IdCategory = 1,
                IdUploader = 2,
                Name = "That's a title",
                Description = "That's great",
                FileId = new Guid("db7dc17917344372b27ec4508fb1ea85"),
                FileExtension = "png"
            };
            // cat 2
            var image18 = new DbImage
            {
                Id = 18,
                IdCategory = 2,
                IdUploader = 1,
                Name = "Lalala",
                Description = "That's a rather long description",
                FileId = new Guid("14f22be857ab433bb20e2a91538e9931"),
                FileExtension = "png"
            };
            var image19 = new DbImage
            {
                Id = 19,
                IdCategory = 2,
                IdUploader = 1,
                Name = "Not good",
                Description = "Nope nope nope",
                FileId = new Guid("02f4340c01e14e90844a165ab8027fe1"),
                FileExtension = "png"
            };
            var image20 = new DbImage
            {
                Id = 20,
                IdCategory = 2,
                IdUploader = 1,
                Name = "Something",
                Description = "That's a rather long description, like really long",
                FileId = new Guid("2dd1b1661f1d45ceb4aa648dd2e135cb"),
                FileExtension = "png"
            };
            var image21 = new DbImage
            {
                Id = 21,
                IdCategory = 2,
                IdUploader = 1,
                Name = "That's the id 21",
                Description = null,
                FileId = new Guid("f316398a86d84f139b7146565e50e0e6"),
                FileExtension = "png"
            };
            var image22 = new DbImage
            {
                Id = 22,
                IdCategory = 2,
                IdUploader = 1,
                Name = "That's the id 22",
                Description = null,
                FileId = new Guid("ed7fd773ef0f4ecca0c67bebe23359da"),
                FileExtension = "png"
            };
            var image23 = new DbImage
            {
                Id = 23,
                IdCategory = 2,
                IdUploader = 1,
                Name = null,
                Description = null,
                FileId = new Guid("6e11274767b14b6895174d44e7b2b0fe"),
                FileExtension = "jpg"
            };
            var image24 = new DbImage
            {
                Id = 24,
                IdCategory = 2,
                IdUploader = 1,
                Name = "Test",
                Description = null,
                FileId = new Guid("e765abae7db941b5bbf605be6102ecaa"),
                FileExtension = "png"
            };

            var image25 = new DbImage
            {
                Id = 25,
                IdCategory = 2,
                IdUploader = 2,
                Name = "That's image 25",
                Description = "Description",
                FileId = new Guid("6663128d864045c3ab6b70d8b6d80270"),
                FileExtension = "png"
            };
            var image26 = new DbImage
            {
                Id = 26,
                IdCategory = 2,
                IdUploader = 2,
                Name = "That's image 26",
                Description = "nghhh",
                FileId = new Guid("5c68ca911ace45049997365938e1bafa"),
                FileExtension = "png"
            };
            var image27 = new DbImage
            {
                Id = 27,
                IdCategory = 2,
                IdUploader = 2,
                Name = "That's image 27",
                Description = "That's a rather long description like really super horribly long like is this really necessary stop it now",
                FileId = new Guid("9b3702bb5598472dab5408d49c0c2987"),
                FileExtension = "png"
            };
            var image28 = new DbImage
            {
                Id = 28,
                IdCategory = 2,
                IdUploader = 2,
                Name = "That's image 28",
                Description = "Bored",
                FileId = new Guid("5f153307e70c477491445a9946b118db"),
                FileExtension = "png"
            };
            var image29 = new DbImage
            {
                Id = 29,
                IdCategory = 2,
                IdUploader = 2,
                Name = "That's image 29",
                Description = "Yololo",
                FileId = new Guid("ed0303c101ca46dba617cad442d60331"),
                FileExtension = "png"
            };
            var image30 = new DbImage
            {
                Id = 30,
                IdCategory = 2,
                IdUploader = 2,
                Name = "a",
                Description = "desc",
                FileId = new Guid("5466bcea687c41bbb70ecfb4309a61f3"),
                FileExtension = "jpg"
            };
            var image31 = new DbImage
            {
                Id = 31,
                IdCategory = 2,
                IdUploader = 2,
                Name = "blah",
                Description = "not",
                FileId = new Guid("ba05b9d7ee1145dca93834cedd85c7a1"),
                FileExtension = "jpg"
            };
            var image32 = new DbImage
            {
                Id = 32,
                IdCategory = 2,
                IdUploader = 2,
                Name = "That's image 32",
                Description = null,
                FileId = new Guid("34855651602d4fa7889326a22212ff70"),
                FileExtension = "png"
            };
            var image33 = new DbImage
            {
                Id = 33,
                IdCategory = 2,
                IdUploader = 2,
                Name = null,
                Description = "Description for image 33",
                FileId = new Guid("b0b37c95a8334ee68946b10f8738e767"),
                FileExtension = "png"
            };
            var image34 = new DbImage
            {
                Id = 34,
                IdCategory = 2,
                IdUploader = 2,
                Name = null,
                Description = "Description for image 34",
                FileId = new Guid("35696e783af746ec9a4ed862ebc59620"),
                FileExtension = "jpg"
            };
            var image35 = new DbImage
            {
                Id = 35,
                IdCategory = 2,
                IdUploader = 2,
                Name = "Something something something",
                Description = "what?",
                FileId = new Guid("0d8de8d2c57e47a4959841f409cca22f"),
                FileExtension = "jpg"
            };
            var image36 = new DbImage
            {
                Id = 36,
                IdCategory = 2,
                IdUploader = 2,
                Name = null,
                Description = null,
                FileId = new Guid("98f7e09d0363492397a1c16e88015909"),
                FileExtension = "png"
            };
            var image37 = new DbImage
            {
                Id = 37,
                IdCategory = 2,
                IdUploader = 2,
                Name = null,
                Description = null,
                FileId = new Guid("743ec8da043349db9c6a768a2db5fec4"),
                FileExtension = "png"
            };
            var image38 = new DbImage
            {
                Id = 38,
                IdCategory = 2,
                IdUploader = 2,
                Name = "Lili",
                Description = "originality",
                FileId = new Guid("3ebcb683bd0542f9b5959ea0972a409f"),
                FileExtension = "jpg"
            };
            var image39 = new DbImage
            {
                Id = 39,
                IdCategory = 2,
                IdUploader = 1,
                Name = "Stop",
                Description = "That's a description",
                FileId = new Guid("0918d9738bff40008a64fdbff5bb3eee"),
                FileExtension = "png"
            };
            var image40 = new DbImage
            {
                Id = 40,
                IdCategory = 2,
                IdUploader = 1,
                Name = "Huge",
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed posuere non magna a luctus. Suspendisse gravida ipsum eu metus dapibus bibendum. Nunc dapibus odio turpis, in maximus nisl hendrerit id. Integer malesuada pharetra nibh, eget cursus sapien molestie nec. Nulla blandit tortor augue, et consectetur lectus egestas sed. Pellentesque blandit consequat euismod. In at feugiat nulla, vel tempor urna. Proin varius, turpis non viverra venenatis",
                FileId = new Guid("659eb8e26fe140cebd30a52e1378efbe"),
                FileExtension = "png"
            };
            var image41 = new DbImage
            {
                Id = 41,
                IdCategory = 2,
                IdUploader = 2,
                Name = null,
                Description = null,
                FileId = new Guid("69f718225c9a4a50a241d1011a1d847a"),
                FileExtension = "jpg"
            };
            var image42 = new DbImage
            {
                Id = 42,
                IdCategory = 2,
                IdUploader = 2,
                Name = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed posuere non magna a luctus. Suspendisse gravida ipsum eu metus",
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed posuere non magna a luctus. Suspendisse gravida ipsum eu metus",
                FileId = new Guid("45ed3c53370b446d83076699d5fdef58"),
                FileExtension = "png"
            };
            var image43 = new DbImage
            {
                Id = 43,
                IdCategory = 2,
                IdUploader = 2,
                Name = "Ffffffff",
                Description = "boring",
                FileId = new Guid("1db7b3b8b2604d09956a7101f7a621f7"),
                FileExtension = "png"
            };
            var image44 = new DbImage
            {
                Id = 44,
                IdCategory = 2,
                IdUploader = 2,
                Name = "Finally",
                Description = "Annoying",
                FileId = new Guid("5f56e5c7ac66467ea475cd7de17077fb"),
                FileExtension = "png"
            };
            var image45 = new DbImage
            {
                Id = 45,
                IdCategory = 2,
                IdUploader = 2,
                Name = "agagaga",
                Description = "grrrr",
                FileId = new Guid("61b8ad267bec46ada3fb2e7fcf8a7de5"),
                FileExtension = "png"
            };
            #endregion

            #region Tags
            var tag1 = new DbTag
            {
                Id = 1,
                Name = "Cool",
                Images = new List<DbImage>()
            };
            var tag2 = new DbTag
            {
                Id = 2,
                Name = "Meh",
                Images = new List<DbImage>()
            };
            var tag3 = new DbTag
            {
                Id = 3,
                Name = "Bad",
                Images = new List<DbImage>()
            };
            #endregion

            tag1.Images.Add(image1);
            tag1.Images.Add(image2);
            tag1.Images.Add(image3);
            tag1.Images.Add(image4);
            tag1.Images.Add(image5);
            tag1.Images.Add(image6);
            tag1.Images.Add(image7);
            tag1.Images.Add(image8);
            tag1.Images.Add(image9);
            tag1.Images.Add(image10);
            tag1.Images.Add(image11);
            tag1.Images.Add(image12);
            tag1.Images.Add(image13);
            tag1.Images.Add(image14);
            tag1.Images.Add(image15);
            tag1.Images.Add(image16);

            tag2.Images.Add(image19);
            tag2.Images.Add(image20);
            tag2.Images.Add(image21);
            tag2.Images.Add(image22);
            tag2.Images.Add(image23);
            tag2.Images.Add(image24);
            tag2.Images.Add(image25);
            tag2.Images.Add(image26);
            tag2.Images.Add(image27);
            tag2.Images.Add(image2);

            tag3.Images.Add(image19);
            tag3.Images.Add(image20);
            tag3.Images.Add(image21);
            tag3.Images.Add(image22);
            tag3.Images.Add(image23);
            tag3.Images.Add(image24);
            tag3.Images.Add(image25);
            tag3.Images.Add(image26);
            tag3.Images.Add(image27);
            tag3.Images.Add(image28);
            tag3.Images.Add(image29);
            tag3.Images.Add(image30);
            tag3.Images.Add(image31);
            tag3.Images.Add(image32);
            tag3.Images.Add(image33);
            tag3.Images.Add(image34);
            tag3.Images.Add(image35);
            tag3.Images.Add(image36);
            tag3.Images.Add(image37);
            tag3.Images.Add(image38);
            tag3.Images.Add(image39);
            tag3.Images.Add(image40);
            tag3.Images.Add(image41);
            tag3.Images.Add(image42);
            tag3.Images.Add(image43);
            tag3.Images.Add(image44);
            tag3.Images.Add(image1);
            tag3.Images.Add(image3);

            context.Categories.Add(Category1);
            context.Categories.Add(Category2);
            context.Categories.Add(Category3);

            context.Users.Add(user1);
            context.Users.Add(user2);

            context.Images.Add(image1);
            context.Images.Add(image2);
            context.Images.Add(image3);
            context.Images.Add(image4);
            context.Images.Add(image5);
            context.Images.Add(image6);
            context.Images.Add(image7);
            context.Images.Add(image8);
            context.Images.Add(image9);
            context.Images.Add(image10);
            context.Images.Add(image11);
            context.Images.Add(image12);
            context.Images.Add(image13);
            context.Images.Add(image14);
            context.Images.Add(image15);
            context.Images.Add(image16);
            context.Images.Add(image17);
            context.Images.Add(image18);
            context.Images.Add(image19);
            context.Images.Add(image20);
            context.Images.Add(image21);
            context.Images.Add(image22);
            context.Images.Add(image23);
            context.Images.Add(image24);
            context.Images.Add(image25);
            context.Images.Add(image26);
            context.Images.Add(image27);
            context.Images.Add(image28);
            context.Images.Add(image29);
            context.Images.Add(image30);
            context.Images.Add(image31);
            context.Images.Add(image32);
            context.Images.Add(image33);
            context.Images.Add(image34);
            context.Images.Add(image35);
            context.Images.Add(image36);
            context.Images.Add(image37);
            context.Images.Add(image38);
            context.Images.Add(image39);
            context.Images.Add(image40);
            context.Images.Add(image41);
            context.Images.Add(image42);
            context.Images.Add(image43);
            context.Images.Add(image44);
            context.Images.Add(image45);

            context.Tags.Add(tag1);
            context.Tags.Add(tag2);
            context.Tags.Add(tag3);
        }
    }
}

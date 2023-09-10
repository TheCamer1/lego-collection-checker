namespace LegoCollectionChecker;

public class ColourMap
{
    private readonly List<ColourInfo> colourInfos;

    public ColourMap()
    {
        colourInfos = new List<ColourInfo>
        {
            new ColourInfo("White", 1, Colour.White),
            new ColourInfo("Very Light Gray", 49, Colour.VeryLightGray),
            new ColourInfo("Very Light Bluish Gray", 99, Colour.VeryLightBluishGray),
            new ColourInfo("Light Bluish Gray", 86, Colour.LightBluishGray),
            new ColourInfo("Light Gray", 9, Colour.LightGray),
            new ColourInfo("Dark Gray", 10, Colour.DarkGray),
            new ColourInfo("Dark Bluish Gray", 85, Colour.DarkBluishGray),
            new ColourInfo("Black", 11, Colour.Black),
            new ColourInfo("Dark Red", 59, Colour.DarkRed),
            new ColourInfo("Red", 5, Colour.Red),
            new ColourInfo("Coral", 220, Colour.Coral),
            new ColourInfo("Dark Salmon", 231, Colour.DarkSalmon),
            new ColourInfo("Salmon", 25, Colour.Salmon),
            new ColourInfo("Light Salmon", 26, Colour.LightSalmon),
            new ColourInfo("Sand Red", 58, Colour.SandRed),
            new ColourInfo("Dark Brown", 120, Colour.DarkBrown),
            new ColourInfo("Brown", 8, Colour.Brown),
            new ColourInfo("Light Brown", 91, Colour.LightBrown),
            new ColourInfo("Medium Brown", 240, Colour.MediumBrown),
            new ColourInfo("Reddish Brown", 88, Colour.ReddishBrown),
            new ColourInfo("Fabuland Brown", 106, Colour.FabulandBrown),
            new ColourInfo("Dark Tan", 69, Colour.DarkTan),
            new ColourInfo("Medium Tan", 241, Colour.MediumTan),
            new ColourInfo("Tan", 2, Colour.Tan),
            new ColourInfo("Light Nougat", 90, Colour.LightNougat),
            new ColourInfo("Nougat", 28, Colour.Nougat),
            new ColourInfo("Medium Nougat", 150, Colour.MediumNougat),
            new ColourInfo("Dark Nougat", 225, Colour.DarkNougat),
            new ColourInfo("Fabuland Orange", 160, Colour.FabulandOrange),
            new ColourInfo("Earth Orange", 29, Colour.EarthOrange),
            new ColourInfo("Dark Orange", 68, Colour.DarkOrange),
            new ColourInfo("Rust", 27, Colour.Rust),
            new ColourInfo("Neon Orange", 165, Colour.NeonOrange),
            new ColourInfo("Orange", 4, Colour.Orange),
            new ColourInfo("Medium Orange", 31, Colour.MediumOrange),
            new ColourInfo("Bright Light Orange", 110, Colour.BrightLightOrange),
            new ColourInfo("Light Orange", 32, Colour.LightOrange),
            new ColourInfo("Very Light Orange", 96, Colour.VeryLightOrange),
            new ColourInfo("Dark Yellow", 161, Colour.DarkYellow),
            new ColourInfo("Yellow", 3, Colour.Yellow),
            new ColourInfo("Light Yellow", 33, Colour.LightYellow),
            new ColourInfo("Bright Light Yellow", 103, Colour.BrightLightYellow),
            new ColourInfo("Neon Yellow", 236, Colour.NeonYellow),
            new ColourInfo("Neon Green", 166, Colour.NeonGreen),
            new ColourInfo("Light Lime", 35, Colour.LightLime),
            new ColourInfo("Yellowish Green", 158, Colour.YellowishGreen),
            new ColourInfo("Medium Lime", 76, Colour.MediumLime),
            new ColourInfo("Fabuland Lime", 248, Colour.FabulandLime),
            new ColourInfo("Lime", 34, Colour.Lime),
            new ColourInfo("Dark Olive Green", 242, Colour.DarkOliveGreen),
            new ColourInfo("Olive Green", 155, Colour.OliveGreen),
            new ColourInfo("Dark Green", 80, Colour.DarkGreen),
            new ColourInfo("Green", 6, Colour.Green),
            new ColourInfo("Bright Green", 36, Colour.BrightGreen),
            new ColourInfo("Medium Green", 37, Colour.MediumGreen),
            new ColourInfo("Light Green", 38, Colour.LightGreen),
            new ColourInfo("Sand Green", 48, Colour.SandGreen),
            new ColourInfo("Dark Turquoise", 39, Colour.DarkTurquoise),
            new ColourInfo("Light Turquoise", 40, Colour.LightTurquoise),
            new ColourInfo("Aqua", 41, Colour.Aqua),
            new ColourInfo("Light Aqua", 152, Colour.LightAqua),
            new ColourInfo("Dark Blue", 63, Colour.DarkBlue),
            new ColourInfo("Blue", 7, Colour.Blue),
            new ColourInfo("Dark Azure", 153, Colour.DarkAzure),
            new ColourInfo("Little Robots Blue", 247, Colour.LittleRobotsBlue),
            new ColourInfo("Maersk Blue", 72, Colour.MaerskBlue),
            new ColourInfo("Medium Azure", 156, Colour.MediumAzure),
            new ColourInfo("Sky Blue", 87, Colour.SkyBlue),
            new ColourInfo("Medium Blue", 42, Colour.MediumBlue),
            new ColourInfo("Bright Light Blue", 105, Colour.BrightLightBlue),
            new ColourInfo("Light Blue", 62, Colour.LightBlue),
            new ColourInfo("Sand Blue", 55, Colour.SandBlue),
            new ColourInfo("Dark Blue-Violet", 109, Colour.DarkBlueViolet),
            new ColourInfo("Violet", 43, Colour.Violet),
            new ColourInfo("Blue-Violet", 97, Colour.BlueViolet),
            new ColourInfo("Lilac", 245, Colour.Lilac),
            new ColourInfo("Medium Violet", 73, Colour.MediumViolet),
            new ColourInfo("Light Lilac", 246, Colour.LightLilac),
            new ColourInfo("Light Violet", 44, Colour.LightViolet),
            new ColourInfo("Dark Purple", 89, Colour.DarkPurple),
            new ColourInfo("Purple", 24, Colour.Purple),
            new ColourInfo("Light Purple", 93, Colour.LightPurple),
            new ColourInfo("Medium Lavender", 157, Colour.MediumLavender),
            new ColourInfo("Lavender", 154, Colour.Lavender),
            new ColourInfo("Lavendar", 154, Colour.Lavendar),
            new ColourInfo("Clikits Lavender", 227, Colour.ClikitsLavender),
            new ColourInfo("Sand Purple", 54, Colour.SandPurple),
            new ColourInfo("Magenta", 71, Colour.Magenta),
            new ColourInfo("Dark Pink", 47, Colour.DarkPink),
            new ColourInfo("Medium Dark Pink", 94, Colour.MediumDarkPink),
            new ColourInfo("Bright Pink", 104, Colour.BrightPink),
            new ColourInfo("Pink", 23, Colour.Pink),
            new ColourInfo("Light Pink", 56, Colour.LightPink),
            new ColourInfo("Trans-Clear", 12, Colour.TransClear),
            new ColourInfo("Trans-Brown (Old Trans-Black)", 13, Colour.TransBrownOldTransBlack),
            new ColourInfo("Trans-Black (2023)", 251, Colour.TransBlack),
            new ColourInfo("Trans-Red", 17, Colour.TransRed),
            new ColourInfo("Trans-Neon Orange", 18, Colour.TransNeonOrange),
            new ColourInfo("Trans-Orange", 98, Colour.TransOrange),
            new ColourInfo("Trans-Light Orange", 164, Colour.TransLightOrange),
            new ColourInfo("Trans-Neon Yellow", 121, Colour.TransNeonYellow),
            new ColourInfo("Trans-Yellow", 19, Colour.TransYellow),
            new ColourInfo("Trans-Neon Green", 16, Colour.TransNeonGreen),
            new ColourInfo("Trans-Bright Green", 108, Colour.TransBrightGreen),
            new ColourInfo("Trans-Light Green", 221, Colour.TransLightGreen),
            new ColourInfo("Trans-Light Bright Green", 226, Colour.TransLightBrightGreen),
            new ColourInfo("Trans-Green", 20, Colour.TransGreen),
            new ColourInfo("Trans-Dark Blue", 14, Colour.TransDarkBlue),
            new ColourInfo("Trans-Medium Blue", 74, Colour.TransMediumBlue),
            new ColourInfo("Trans-Light Blue", 15, Colour.TransLightBlue),
            new ColourInfo("Trans-Aqua", 113, Colour.TransAqua),
            new ColourInfo("Trans-Light Purple", 114, Colour.TransLightPurple),
            new ColourInfo("Trans-Medium Purple", 234, Colour.TransMediumPurple),
            new ColourInfo("Trans-Purple", 51, Colour.TransPurple),
            new ColourInfo("Trans-Dark Pink", 50, Colour.TransDarkPink),
            new ColourInfo("Trans-Pink", 107, Colour.TransPink),
            new ColourInfo("Chrome Gold", 21, Colour.ChromeGold),
            new ColourInfo("Chrome Silver", 22, Colour.ChromeSilver),
            new ColourInfo("Chrome Antique Brass", 57, Colour.ChromeAntiqueBrass),
            new ColourInfo("Chrome Black", 122, Colour.ChromeBlack),
            new ColourInfo("Chrome Blue", 52, Colour.ChromeBlue),
            new ColourInfo("Chrome Green", 64, Colour.ChromeGreen),
            new ColourInfo("Chrome Pink", 82, Colour.ChromePink),
            new ColourInfo("Pearl White", 83, Colour.PearlWhite),
            new ColourInfo("Pearl Very Light Gray", 119, Colour.PearlVeryLightGray),
            new ColourInfo("Pearl Light Gray", 66, Colour.PearlLightGray),
            new ColourInfo("Flat Silver", 95, Colour.FlatSilver),
            new ColourInfo("Bionicle Silver", 239, Colour.BionicleSilver),
            new ColourInfo("Pearl Dark Gray", 77, Colour.PearlDarkGray),
            new ColourInfo("Pearl Black", 244, Colour.PearlBlack),
            new ColourInfo("Pearl Light Gold", 61, Colour.PearlLightGold),
            new ColourInfo("Pearl Gold", 115, Colour.PearlGold),
            new ColourInfo("Reddish Gold", 235, Colour.ReddishGold),
            new ColourInfo("Bionicle Gold", 238, Colour.BionicleGold),
            new ColourInfo("Flat Dark Gold", 81, Colour.FlatDarkGold),
            new ColourInfo("Reddish Copper", 249, Colour.ReddishCopper),
            new ColourInfo("Copper", 84, Colour.Copper),
            new ColourInfo("Bionicl eCopper", 237, Colour.BionicleCopper),
            new ColourInfo("Pearl Sand Blue", 78, Colour.PearlSandBlue),
            new ColourInfo("Pearl Sand Purple", 243, Colour.PearlSandPurple),
            new ColourInfo("Satin Trans-Clear", 228, Colour.SatinTransClear),
            new ColourInfo("Satin Trans-Brown", 229, Colour.SatinTransBrown),
            new ColourInfo("Satin Trans-Bright Green", 233, Colour.SatinTransBrightGreen),
            new ColourInfo("Satin Trans-Light Blue", 223, Colour.SatinTransLightBlue),
            new ColourInfo("Satin Trans-Dark Blue", 232, Colour.SatinTransDarkBlue),
            new ColourInfo("Satin Trans-Purple", 230, Colour.SatinTransPurple),
            new ColourInfo("Satin Trans-Dark Pink", 224, Colour.SatinTransDarkPink),
            new ColourInfo("Metallic Silver", 67, Colour.MetallicSilver),
            new ColourInfo("Metallic Green", 70, Colour.MetallicGreen),
            new ColourInfo("Metallic Gold", 65, Colour.MetallicGold),
            new ColourInfo("Metallic Copper", 250, Colour.MetallicCopper),
            new ColourInfo("Milky White", 60, Colour.MilkyWhite),
            new ColourInfo("Glow In Dark White", 159, Colour.GlowInDarkWhite),
            new ColourInfo("Glow In Dark Opaque", 46, Colour.GlowInDarkOpaque),
            new ColourInfo("Glow In Dark Trans", 118, Colour.GlowInDarkTrans),
            new ColourInfo("Glitter Trans-Clear", 101, Colour.GlitterTransClear),
            new ColourInfo("Glitter Trans-Orange", 222, Colour.GlitterTransOrange),
            new ColourInfo("Glitter Trans-Neon Green", 163, Colour.GlitterTransNeonGreen),
            new ColourInfo("Glitter Trans-Light Blue", 162, Colour.GlitterTransLightBlue),
            new ColourInfo("Glitter Trans-Purple", 102, Colour.GlitterTransPurple),
            new ColourInfo("Glitter Trans-Dark Pink", 100, Colour.GlitterTransDarkPink),
            new ColourInfo("Speckle Black-Silver", 111, Colour.SpeckleBlackSilver),
            new ColourInfo("Speckle Black-Gold", 151, Colour.SpeckleBlackGold),
            new ColourInfo("Speckle Black-Copper", 116, Colour.SpeckleBlackCopper),
            new ColourInfo("Speckle DBGray-Silver", 117, Colour.SpeckleDBGraySilver),
            new ColourInfo("Mx White", 123, Colour.MxWhite),
            new ColourInfo("Mx Light Bluish Gray", 124, Colour.MxLightBluishGray),
            new ColourInfo("Mx Light Gray", 125, Colour.MxLightGray),
            new ColourInfo("Mx Charcoal Gray", 126, Colour.MxCharcoalGray),
            new ColourInfo("Mx Tile Gray", 127, Colour.MxTileGray),
            new ColourInfo("Mx Black", 128, Colour.MxBlack),
            new ColourInfo("Mx Tile Brown", 131, Colour.MxTileBrown),
            new ColourInfo("Mx Terracotta", 134, Colour.MxTerracotta),
            new ColourInfo("Mx Brown", 132, Colour.MxBrown),
            new ColourInfo("Mx Buff", 133, Colour.MxBuff),
            new ColourInfo("Mx Red", 129, Colour.MxRed),
            new ColourInfo("Mx Pink Red", 130, Colour.MxPinkRed),
            new ColourInfo("Mx Orange", 135, Colour.MxOrange),
            new ColourInfo("Mx Light Orange", 136, Colour.MxLightOrange),
            new ColourInfo("Mx Light Yellow", 137, Colour.MxLightYellow),
            new ColourInfo("Mx Ochre Yellow", 138, Colour.MxOchreYellow),
            new ColourInfo("Mx Lemon", 139, Colour.MxLemon),
            new ColourInfo("Mx Pastel Green", 141, Colour.MxPastelGreen),
            new ColourInfo("Mx Olive Green", 140, Colour.MxOliveGreen),
            new ColourInfo("Mx Aqua Green", 142, Colour.MxAquaGreen),
            new ColourInfo("Mx Teal Blue", 146, Colour.MxTealBlue),
            new ColourInfo("Mx Tile Blue", 143, Colour.MxTileBlue),
            new ColourInfo("Mx Medium Blue", 144, Colour.MxMediumBlue),
            new ColourInfo("Mx Pastel Blue", 145, Colour.MxPastelBlue),
            new ColourInfo("Mx Violet", 147, Colour.MxViolet),
            new ColourInfo("Mx Pink", 148, Colour.MxPink),
            new ColourInfo("Mx Clear", 149, Colour.MxClear),
            new ColourInfo("Mx Foil Dark Gray", 210, Colour.MxFoilDarkGray),
            new ColourInfo("Mx Foil Light Gray", 211, Colour.MxFoilLightGray),
            new ColourInfo("Mx Foil Dark Green", 212, Colour.MxFoilDarkGreen),
            new ColourInfo("Mx Foil Light Green", 213, Colour.MxFoilLightGreen),
            new ColourInfo("Mx Foil Dark Blue", 214, Colour.MxFoilDarkBlue),
            new ColourInfo("Mx Foil Light Blue", 215, Colour.MxFoilLightBlue),
            new ColourInfo("Mx Foil Violet", 216, Colour.MxFoilViolet),
            new ColourInfo("Mx Foil Red", 217, Colour.MxFoilRed),
            new ColourInfo("Mx Foil Yellow", 218, Colour.MxFoilYellow),
            new ColourInfo("Mx Foil Orange", 219, Colour.MxFoilOrange)
        };
    }

    public bool ContainsColour(string name)
    {
        return colourInfos.Any(e => e.Name == name);
    }

    public bool ContainsColour(Colour colour)
    {
        return colourInfos.Any(e => e.EnumValue == colour);
    }

    public string? GetNameById(int id)
    {
        return colourInfos.FirstOrDefault(ci => ci.Id == id)?.Name;
    }

    public int? GetIdByName(string name)
    {
        return colourInfos.FirstOrDefault(ci => ci.Name == name)?.Id;
    }

    public Colour? GetEnumById(int id)
    {
        return colourInfos.FirstOrDefault(ci => ci.Id == id)?.EnumValue;
    }

    public Colour? GetEnumByName(string name)
    {
        return colourInfos.FirstOrDefault(ci => ci.Name == name)?.EnumValue;
    }

    public int? GetIdByEnum(Colour enumValue)
    {
        return colourInfos.FirstOrDefault(ci => ci.EnumValue == enumValue)?.Id;
    }

    public string? GetNameByEnum(Colour enumValue)
    {
        return colourInfos.FirstOrDefault(ci => ci.EnumValue == enumValue)?.Name;
    }

    public class ColourInfo
    {
        public string Name { get; }
        public int Id { get; }
        public Colour EnumValue { get; }

        public ColourInfo(string name, int id, Colour enumValue)
        {
            Name = name;
            Id = id;
            EnumValue = enumValue;
        }
    }
}

namespace LegoCollectionChecker;

public class ColourMap
{
    private readonly List<ColourInfo> colourInfos;

    public ColourMap()
    {
        colourInfos = new List<ColourInfo>
        {
            new ColourInfo("White", 1, ColourEnum.White),
            new ColourInfo("Very Light Gray", 49, ColourEnum.VeryLightGray),
            new ColourInfo("Very Light Bluish Gray", 99, ColourEnum.VeryLightBluishGray),
            new ColourInfo("Light Bluish Gray", 86, ColourEnum.LightBluishGray),
            new ColourInfo("Light Gray", 9, ColourEnum.LightGray),
            new ColourInfo("Dark Gray", 10, ColourEnum.DarkGray),
            new ColourInfo("Dark Bluish Gray", 85, ColourEnum.DarkBluishGray),
            new ColourInfo("Black", 11, ColourEnum.Black),
            new ColourInfo("Dark Red", 59, ColourEnum.DarkRed),
            new ColourInfo("Red", 5, ColourEnum.Red),
            new ColourInfo("Coral", 220, ColourEnum.Coral),
            new ColourInfo("Dark Salmon", 231, ColourEnum.DarkSalmon),
            new ColourInfo("Salmon", 25, ColourEnum.Salmon),
            new ColourInfo("Light Salmon", 26, ColourEnum.LightSalmon),
            new ColourInfo("Sand Red", 58, ColourEnum.SandRed),
            new ColourInfo("Dark Brown", 120, ColourEnum.DarkBrown),
            new ColourInfo("Brown", 8, ColourEnum.Brown),
            new ColourInfo("Light Brown", 91, ColourEnum.LightBrown),
            new ColourInfo("Medium Brown", 240, ColourEnum.MediumBrown),
            new ColourInfo("Reddish Brown", 88, ColourEnum.ReddishBrown),
            new ColourInfo("Fabuland Brown", 106, ColourEnum.FabulandBrown),
            new ColourInfo("Dark Tan", 69, ColourEnum.DarkTan),
            new ColourInfo("Medium Tan", 241, ColourEnum.MediumTan),
            new ColourInfo("Tan", 2, ColourEnum.Tan),
            new ColourInfo("Light Nougat", 90, ColourEnum.LightNougat),
            new ColourInfo("Nougat", 28, ColourEnum.Nougat),
            new ColourInfo("Medium Nougat", 150, ColourEnum.MediumNougat),
            new ColourInfo("Dark Nougat", 225, ColourEnum.DarkNougat),
            new ColourInfo("Fabuland Orange", 160, ColourEnum.FabulandOrange),
            new ColourInfo("Earth Orange", 29, ColourEnum.EarthOrange),
            new ColourInfo("Dark Orange", 68, ColourEnum.DarkOrange),
            new ColourInfo("Rust", 27, ColourEnum.Rust),
            new ColourInfo("Neon Orange", 165, ColourEnum.NeonOrange),
            new ColourInfo("Orange", 4, ColourEnum.Orange),
            new ColourInfo("Medium Orange", 31, ColourEnum.MediumOrange),
            new ColourInfo("Bright Light Orange", 110, ColourEnum.BrightLightOrange),
            new ColourInfo("Light Orange", 32, ColourEnum.LightOrange),
            new ColourInfo("Very Light Orange", 96, ColourEnum.VeryLightOrange),
            new ColourInfo("Dark Yellow", 161, ColourEnum.DarkYellow),
            new ColourInfo("Yellow", 3, ColourEnum.Yellow),
            new ColourInfo("Light Yellow", 33, ColourEnum.LightYellow),
            new ColourInfo("Bright Light Yellow", 103, ColourEnum.BrightLightYellow),
            new ColourInfo("Neon Yellow", 236, ColourEnum.NeonYellow),
            new ColourInfo("Neon Green", 166, ColourEnum.NeonGreen),
            new ColourInfo("Light Lime", 35, ColourEnum.LightLime),
            new ColourInfo("Yellowish Green", 158, ColourEnum.YellowishGreen),
            new ColourInfo("Medium Lime", 76, ColourEnum.MediumLime),
            new ColourInfo("Fabuland Lime", 248, ColourEnum.FabulandLime),
            new ColourInfo("Lime", 34, ColourEnum.Lime),
            new ColourInfo("Dark Olive Green", 242, ColourEnum.DarkOliveGreen),
            new ColourInfo("Olive Green", 155, ColourEnum.OliveGreen),
            new ColourInfo("Dark Green", 80, ColourEnum.DarkGreen),
            new ColourInfo("Green", 6, ColourEnum.Green),
            new ColourInfo("Bright Green", 36, ColourEnum.BrightGreen),
            new ColourInfo("Medium Green", 37, ColourEnum.MediumGreen),
            new ColourInfo("Light Green", 38, ColourEnum.LightGreen),
            new ColourInfo("Sand Green", 48, ColourEnum.SandGreen),
            new ColourInfo("Dark Turquoise", 39, ColourEnum.DarkTurquoise),
            new ColourInfo("Light Turquoise", 40, ColourEnum.LightTurquoise),
            new ColourInfo("Aqua", 41, ColourEnum.Aqua),
            new ColourInfo("Light Aqua", 152, ColourEnum.LightAqua),
            new ColourInfo("Dark Blue", 63, ColourEnum.DarkBlue),
            new ColourInfo("Blue", 7, ColourEnum.Blue),
            new ColourInfo("Dark Azure", 153, ColourEnum.DarkAzure),
            new ColourInfo("Little Robots Blue", 247, ColourEnum.LittleRobotsBlue),
            new ColourInfo("Maersk Blue", 72, ColourEnum.MaerskBlue),
            new ColourInfo("Medium Azure", 156, ColourEnum.MediumAzure),
            new ColourInfo("Sky Blue", 87, ColourEnum.SkyBlue),
            new ColourInfo("Medium Blue", 42, ColourEnum.MediumBlue),
            new ColourInfo("Bright Light Blue", 105, ColourEnum.BrightLightBlue),
            new ColourInfo("Light Blue", 62, ColourEnum.LightBlue),
            new ColourInfo("Sand Blue", 55, ColourEnum.SandBlue),
            new ColourInfo("Dark Blue-Violet", 109, ColourEnum.DarkBlueViolet),
            new ColourInfo("Violet", 43, ColourEnum.Violet),
            new ColourInfo("Blue-Violet", 97, ColourEnum.BlueViolet),
            new ColourInfo("Lilac", 245, ColourEnum.Lilac),
            new ColourInfo("Medium Violet", 73, ColourEnum.MediumViolet),
            new ColourInfo("Light Lilac", 246, ColourEnum.LightLilac),
            new ColourInfo("Light Violet", 44, ColourEnum.LightViolet),
            new ColourInfo("Dark Purple", 89, ColourEnum.DarkPurple),
            new ColourInfo("Purple", 24, ColourEnum.Purple),
            new ColourInfo("Light Purple", 93, ColourEnum.LightPurple),
            new ColourInfo("Medium Lavender", 157, ColourEnum.MediumLavender),
            new ColourInfo("Lavender", 154, ColourEnum.Lavender),
            new ColourInfo("Lavendar", 154, ColourEnum.Lavendar),
            new ColourInfo("Clikits Lavender", 227, ColourEnum.ClikitsLavender),
            new ColourInfo("Sand Purple", 54, ColourEnum.SandPurple),
            new ColourInfo("Magenta", 71, ColourEnum.Magenta),
            new ColourInfo("Dark Pink", 47, ColourEnum.DarkPink),
            new ColourInfo("Medium Dark Pink", 94, ColourEnum.MediumDarkPink),
            new ColourInfo("Bright Pink", 104, ColourEnum.BrightPink),
            new ColourInfo("Pink", 23, ColourEnum.Pink),
            new ColourInfo("Light Pink", 56, ColourEnum.LightPink),
            new ColourInfo("Trans-Clear", 12, ColourEnum.TransClear),
            new ColourInfo("Trans-Brown (Old Trans-Black)", 13, ColourEnum.TransBrownOldTransBlack),
            new ColourInfo("Trans-Black (2023)", 251, ColourEnum.TransBlack),
            new ColourInfo("Trans-Red", 17, ColourEnum.TransRed),
            new ColourInfo("Trans-Neon Orange", 18, ColourEnum.TransNeonOrange),
            new ColourInfo("Trans-Orange", 98, ColourEnum.TransOrange),
            new ColourInfo("Trans-Light Orange", 164, ColourEnum.TransLightOrange),
            new ColourInfo("Trans-Neon Yellow", 121, ColourEnum.TransNeonYellow),
            new ColourInfo("Trans-Yellow", 19, ColourEnum.TransYellow),
            new ColourInfo("Trans-Neon Green", 16, ColourEnum.TransNeonGreen),
            new ColourInfo("Trans-Bright Green", 108, ColourEnum.TransBrightGreen),
            new ColourInfo("Trans-Light Green", 221, ColourEnum.TransLightGreen),
            new ColourInfo("Trans-Light Bright Green", 226, ColourEnum.TransLightBrightGreen),
            new ColourInfo("Trans-Green", 20, ColourEnum.TransGreen),
            new ColourInfo("Trans-Dark Blue", 14, ColourEnum.TransDarkBlue),
            new ColourInfo("Trans-Medium Blue", 74, ColourEnum.TransMediumBlue),
            new ColourInfo("Trans-Light Blue", 15, ColourEnum.TransLightBlue),
            new ColourInfo("Trans-Aqua", 113, ColourEnum.TransAqua),
            new ColourInfo("Trans-Light Purple", 114, ColourEnum.TransLightPurple),
            new ColourInfo("Trans-Medium Purple", 234, ColourEnum.TransMediumPurple),
            new ColourInfo("Trans-Purple", 51, ColourEnum.TransPurple),
            new ColourInfo("Trans-Dark Pink", 50, ColourEnum.TransDarkPink),
            new ColourInfo("Trans-Pink", 107, ColourEnum.TransPink),
            new ColourInfo("Chrome Gold", 21, ColourEnum.ChromeGold),
            new ColourInfo("Chrome Silver", 22, ColourEnum.ChromeSilver),
            new ColourInfo("Chrome Antique Brass", 57, ColourEnum.ChromeAntiqueBrass),
            new ColourInfo("Chrome Black", 122, ColourEnum.ChromeBlack),
            new ColourInfo("Chrome Blue", 52, ColourEnum.ChromeBlue),
            new ColourInfo("Chrome Green", 64, ColourEnum.ChromeGreen),
            new ColourInfo("Chrome Pink", 82, ColourEnum.ChromePink),
            new ColourInfo("Pearl White", 83, ColourEnum.PearlWhite),
            new ColourInfo("Pearl Very Light Gray", 119, ColourEnum.PearlVeryLightGray),
            new ColourInfo("Pearl Light Gray", 66, ColourEnum.PearlLightGray),
            new ColourInfo("Flat Silver", 95, ColourEnum.FlatSilver),
            new ColourInfo("Bionicle Silver", 239, ColourEnum.BionicleSilver),
            new ColourInfo("Pearl Dark Gray", 77, ColourEnum.PearlDarkGray),
            new ColourInfo("Pearl Black", 244, ColourEnum.PearlBlack),
            new ColourInfo("Pearl Light Gold", 61, ColourEnum.PearlLightGold),
            new ColourInfo("Pearl Gold", 115, ColourEnum.PearlGold),
            new ColourInfo("Reddish Gold", 235, ColourEnum.ReddishGold),
            new ColourInfo("Bionicle Gold", 238, ColourEnum.BionicleGold),
            new ColourInfo("Flat Dark Gold", 81, ColourEnum.FlatDarkGold),
            new ColourInfo("Reddish Copper", 249, ColourEnum.ReddishCopper),
            new ColourInfo("Copper", 84, ColourEnum.Copper),
            new ColourInfo("Bionicl eCopper", 237, ColourEnum.BionicleCopper),
            new ColourInfo("Pearl Sand Blue", 78, ColourEnum.PearlSandBlue),
            new ColourInfo("Pearl Sand Purple", 243, ColourEnum.PearlSandPurple),
            new ColourInfo("Satin Trans-Clear", 228, ColourEnum.SatinTransClear),
            new ColourInfo("Satin Trans-Brown", 229, ColourEnum.SatinTransBrown),
            new ColourInfo("Satin Trans-Bright Green", 233, ColourEnum.SatinTransBrightGreen),
            new ColourInfo("Satin Trans-Light Blue", 223, ColourEnum.SatinTransLightBlue),
            new ColourInfo("Satin Trans-Dark Blue", 232, ColourEnum.SatinTransDarkBlue),
            new ColourInfo("Satin Trans-Purple", 230, ColourEnum.SatinTransPurple),
            new ColourInfo("Satin Trans-Dark Pink", 224, ColourEnum.SatinTransDarkPink),
            new ColourInfo("Metallic Silver", 67, ColourEnum.MetallicSilver),
            new ColourInfo("Metallic Green", 70, ColourEnum.MetallicGreen),
            new ColourInfo("Metallic Gold", 65, ColourEnum.MetallicGold),
            new ColourInfo("Metallic Copper", 250, ColourEnum.MetallicCopper),
            new ColourInfo("Milky White", 60, ColourEnum.MilkyWhite),
            new ColourInfo("Glow In Dark White", 159, ColourEnum.GlowInDarkWhite),
            new ColourInfo("Glow In Dark Opaque", 46, ColourEnum.GlowInDarkOpaque),
            new ColourInfo("Glow In Dark Trans", 118, ColourEnum.GlowInDarkTrans),
            new ColourInfo("Glitter Trans-Clear", 101, ColourEnum.GlitterTransClear),
            new ColourInfo("Glitter Trans-Orange", 222, ColourEnum.GlitterTransOrange),
            new ColourInfo("Glitter Trans-Neon Green", 163, ColourEnum.GlitterTransNeonGreen),
            new ColourInfo("Glitter Trans-Light Blue", 162, ColourEnum.GlitterTransLightBlue),
            new ColourInfo("Glitter Trans-Purple", 102, ColourEnum.GlitterTransPurple),
            new ColourInfo("Glitter Trans-Dark Pink", 100, ColourEnum.GlitterTransDarkPink),
            new ColourInfo("Speckle Black-Silver", 111, ColourEnum.SpeckleBlackSilver),
            new ColourInfo("Speckle Black-Gold", 151, ColourEnum.SpeckleBlackGold),
            new ColourInfo("Speckle Black-Copper", 116, ColourEnum.SpeckleBlackCopper),
            new ColourInfo("Speckle DBGray-Silver", 117, ColourEnum.SpeckleDBGraySilver),
            new ColourInfo("Mx White", 123, ColourEnum.MxWhite),
            new ColourInfo("Mx Light Bluish Gray", 124, ColourEnum.MxLightBluishGray),
            new ColourInfo("Mx Light Gray", 125, ColourEnum.MxLightGray),
            new ColourInfo("Mx Charcoal Gray", 126, ColourEnum.MxCharcoalGray),
            new ColourInfo("Mx Tile Gray", 127, ColourEnum.MxTileGray),
            new ColourInfo("Mx Black", 128, ColourEnum.MxBlack),
            new ColourInfo("Mx Tile Brown", 131, ColourEnum.MxTileBrown),
            new ColourInfo("Mx Terracotta", 134, ColourEnum.MxTerracotta),
            new ColourInfo("Mx Brown", 132, ColourEnum.MxBrown),
            new ColourInfo("Mx Buff", 133, ColourEnum.MxBuff),
            new ColourInfo("Mx Red", 129, ColourEnum.MxRed),
            new ColourInfo("Mx Pink Red", 130, ColourEnum.MxPinkRed),
            new ColourInfo("Mx Orange", 135, ColourEnum.MxOrange),
            new ColourInfo("Mx Light Orange", 136, ColourEnum.MxLightOrange),
            new ColourInfo("Mx Light Yellow", 137, ColourEnum.MxLightYellow),
            new ColourInfo("Mx Ochre Yellow", 138, ColourEnum.MxOchreYellow),
            new ColourInfo("Mx Lemon", 139, ColourEnum.MxLemon),
            new ColourInfo("Mx Pastel Green", 141, ColourEnum.MxPastelGreen),
            new ColourInfo("Mx Olive Green", 140, ColourEnum.MxOliveGreen),
            new ColourInfo("Mx Aqua Green", 142, ColourEnum.MxAquaGreen),
            new ColourInfo("Mx Teal Blue", 146, ColourEnum.MxTealBlue),
            new ColourInfo("Mx Tile Blue", 143, ColourEnum.MxTileBlue),
            new ColourInfo("Mx Medium Blue", 144, ColourEnum.MxMediumBlue),
            new ColourInfo("Mx Pastel Blue", 145, ColourEnum.MxPastelBlue),
            new ColourInfo("Mx Violet", 147, ColourEnum.MxViolet),
            new ColourInfo("Mx Pink", 148, ColourEnum.MxPink),
            new ColourInfo("Mx Clear", 149, ColourEnum.MxClear),
            new ColourInfo("Mx Foil Dark Gray", 210, ColourEnum.MxFoilDarkGray),
            new ColourInfo("Mx Foil Light Gray", 211, ColourEnum.MxFoilLightGray),
            new ColourInfo("Mx Foil Dark Green", 212, ColourEnum.MxFoilDarkGreen),
            new ColourInfo("Mx Foil Light Green", 213, ColourEnum.MxFoilLightGreen),
            new ColourInfo("Mx Foil Dark Blue", 214, ColourEnum.MxFoilDarkBlue),
            new ColourInfo("Mx Foil Light Blue", 215, ColourEnum.MxFoilLightBlue),
            new ColourInfo("Mx Foil Violet", 216, ColourEnum.MxFoilViolet),
            new ColourInfo("Mx Foil Red", 217, ColourEnum.MxFoilRed),
            new ColourInfo("Mx Foil Yellow", 218, ColourEnum.MxFoilYellow),
            new ColourInfo("Mx Foil Orange", 219, ColourEnum.MxFoilOrange)
        };
    }

    public bool ContainsColour(string name)
    {
        return colourInfos.Any(e => e.Name == name);
    }

    public string? GetNameById(int id)
    {
        return colourInfos.FirstOrDefault(ci => ci.Id == id)?.Name;
    }

    public int? GetIdByName(string name)
    {
        return colourInfos.FirstOrDefault(ci => ci.Name == name)?.Id;
    }

    public ColourEnum? GetEnumById(int id)
    {
        return colourInfos.FirstOrDefault(ci => ci.Id == id)?.EnumValue;
    }

    public ColourEnum? GetEnumByName(string name)
    {
        return colourInfos.FirstOrDefault(ci => ci.Name == name)?.EnumValue;
    }

    public int? GetIdByEnum(ColourEnum enumValue)
    {
        return colourInfos.FirstOrDefault(ci => ci.EnumValue == enumValue)?.Id;
    }

    public string? GetNameByEnum(ColourEnum enumValue)
    {
        return colourInfos.FirstOrDefault(ci => ci.EnumValue == enumValue)?.Name;
    }

    public class ColourInfo
    {
        public string Name { get; }
        public int Id { get; }
        public ColourEnum EnumValue { get; }

        public ColourInfo(string name, int id, ColourEnum enumValue)
        {
            Name = name;
            Id = id;
            EnumValue = enumValue;
        }
    }
}

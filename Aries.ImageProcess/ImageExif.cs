﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aries.ImageProcess
{
    /// <summary>
    /// 图片EXIF信息处理类
    /// </summary>
    public class ImageExif
    {
        #region Field
        /// <summary>
        /// 图片
        /// </summary>
        private Image image;

        /// <summary>
        /// 编码
        /// </summary>
        private Encoding encoding = Encoding.UTF8;
        #endregion //Field

        #region Constructor
        public ImageExif(string fileName)
        {
            this.image = Image.FromFile(fileName);
        }
        #endregion //Constructor

        #region Function
        /// <summary>
        /// 检查属性是否定义
        /// </summary>
        /// <param name="pid">属性ID</param>
        /// <returns></returns>
        private bool IsPropertyDefined(int pid)
        {
            return (Array.IndexOf(this.image.PropertyIdList, pid) > -1);
        }


        public Int32 GetPropertyInt32(int pid)
        {
            if (IsPropertyDefined(pid))
                return GetInt32(this.image.GetPropertyItem(pid).Value);
            else
                return 0;
        }

        public Int16 GetPropertyInt16(int pid)
        {
            if (IsPropertyDefined(pid))
                return GetInt16(this.image.GetPropertyItem(pid).Value);
            else
                return 0;
        }

        /// <summary>
        /// 获取字符串属性
        /// </summary>
        /// <param name="pid">属性ID</param>
        /// <returns></returns>
        private string GetPropertyString(int pid)
        {
            if (IsPropertyDefined(pid))
                return GetString(this.image.GetPropertyItem(pid).Value);
            else
                return string.Empty;
        }

        /// <summary>
        /// 获取Int32属性
        /// </summary>
        /// <param name="data">数据</param>
        /// <returns></returns>
        private Int32 GetInt32(byte[] data)
        {
            if (data.Length < 4)
                throw new ArgumentException("Data too short (4 bytes expected)", "data");

            return data[3] << 24 | data[2] << 16 | data[1] << 8 | data[0];
        }

        /// <summary>
        /// 获取Int16属性
        /// </summary>
        /// <param name="data">数据</param>
        /// <returns></returns>
        private Int16 GetInt16(byte[] data)
        {
            if (data.Length < 2)
                throw new ArgumentException("Data too short (2 bytes expected)", "data");

            return (short)(data[1] << 8 | data[0]);
        }

        /// <summary>
        /// 获取字符串属性
        /// </summary>
        /// <param name="data">数据</param>
        /// <returns></returns>
        private string GetString(byte[] data)
        {
            string s = this.encoding.GetString(data);
            if (s.EndsWith("\0"))
                s = s.Substring(0, s.Length - 1);
            return s;
        }
        #endregion //Function

        #region Property
        /// <summary>
        /// 拍摄时间
        /// </summary>
        public DateTime DateTime
        {
            get
            {
                try
                {
                    return DateTime.ParseExact(this.GetPropertyString((int)TagNames.DateTime), @"yyyy\:MM\:dd HH\:mm\:ss", null);
                }
                catch
                {
                    return DateTime.MinValue;
                }
            }
            set
            {
                //try
                //{
                //    this.SetPropertyString((int)TagNames.DateTime, value.ToString(@"yyyy\:MM\:dd HH\:mm\:ss"));
                //}
                //catch
                //{ }
            }
        }
        #endregion //Property


        #region TagNames
        /// <summary>
        /// 标签
        /// </summary>
        public enum TagNames : int
        {
            GpsVer = 0x0,
            GpsLatitudeRef = 0x1,
            GpsLatitude = 0x2,
            GpsLongitudeRef = 0x3,
            GpsLongitude = 0x4,
            GpsAltitudeRef = 0x5,
            GpsAltitude = 0x6,
            GpsGpsTime = 0x7,
            GpsGpsSatellites = 0x8,
            GpsGpsStatus = 0x9,
            GpsGpsMeasureMode = 0xA,
            GpsGpsDop = 0xB,
            GpsSpeedRef = 0xC,
            GpsSpeed = 0xD,
            GpsTrackRef = 0xE,
            GpsTrack = 0xF,
            GpsImgDirRef = 0x10,
            GpsImgDir = 0x11,
            GpsMapDatum = 0x12,
            GpsDestLatRef = 0x13,
            GpsDestLat = 0x14,
            GpsDestLongRef = 0x15,
            GpsDestLong = 0x16,
            GpsDestBearRef = 0x17,
            GpsDestBear = 0x18,
            GpsDestDistRef = 0x19,
            GpsDestDist = 0x1A,


            NewSubfileType = 0xFE,
            SubfileType = 0xFF,

            ImageWidth = 0x100,
            ImageHeight = 0x101,
            BitsPerSample = 0x102,
            Compression = 0x103,
            PhotometricInterp = 0x106,
            ThreshHolding = 0x107,
            CellWidth = 0x108,
            CellHeight = 0x109,
            FillOrder = 0x10A,
            DocumentName = 0x10D,
            ImageDescription = 0x10E,
            EquipMake = 0x10F,
            EquipModel = 0x110,
            StripOffsets = 0x111,
            Orientation = 0x112,
            SamplesPerPixel = 0x115,
            RowsPerStrip = 0x116,
            StripBytesCount = 0x117,
            MinSampleValue = 0x118,
            MaxSampleValue = 0x119,
            XResolution = 0x11A,
            YResolution = 0x11B,
            PlanarConfig = 0x11C,
            PageName = 0x11D,
            XPosition = 0x11E,
            YPosition = 0x11F,
            FreeOffset = 0x120,
            FreeByteCounts = 0x121,
            GrayResponseUnit = 0x122,
            GrayResponseCurve = 0x123,
            T4Option = 0x124,
            T6Option = 0x125,
            ResolutionUnit = 0x128,
            PageNumber = 0x129,
            TransferFuncition = 0x12D,
            SoftwareUsed = 0x131,
            DateTime = 0x132,
            Artist = 0x13B,
            HostComputer = 0x13C,
            Predictor = 0x13D,
            WhitePoint = 0x13E,
            PrimaryChromaticities = 0x13F,
            ColorMap = 0x140,
            HalftoneHints = 0x141,
            TileWidth = 0x142,
            TileLength = 0x143,
            TileOffset = 0x144,
            TileByteCounts = 0x145,
            InkSet = 0x14C,
            InkNames = 0x14D,
            NumberOfInks = 0x14E,
            DotRange = 0x150,
            TargetPrinter = 0x151,
            ExtraSamples = 0x152,
            SampleFormat = 0x153,
            SMinSampleValue = 0x154,
            SMaxSampleValue = 0x155,
            TransferRange = 0x156,

            JPEGProc = 0x200,
            JPEGInterFormat = 0x201,
            JPEGInterLength = 0x202,
            JPEGRestartInterval = 0x203,
            JPEGLosslessPredictors = 0x205,
            JPEGPointTransforms = 0x206,
            JPEGQTables = 0x207,
            JPEGDCTables = 0x208,
            JPEGACTables = 0x209,
            YCbCrCoefficients = 0x211,
            YCbCrSubsampling = 0x212,
            YCbCrPositioning = 0x213,
            REFBlackWhite = 0x214,

            Gamma = 0x301,
            ICCProfileDescriptor = 0x302,
            SRGBRenderingIntent = 0x303,
            ImageTitle = 0x320,

            ResolutionXUnit = 0x5001,
            ResolutionYUnit = 0x5002,
            ResolutionXLengthUnit = 0x5003,
            ResolutionYLengthUnit = 0x5004,
            PrintFlags = 0x5005,
            PrintFlagsVersion = 0x5006,
            PrintFlagsCrop = 0x5007,
            PrintFlagsBleedWidth = 0x5008,
            PrintFlagsBleedWidthScale = 0x5009,
            HalftoneLPI = 0x500A,
            HalftoneLPIUnit = 0x500B,
            HalftoneDegree = 0x500C,
            HalftoneShape = 0x500D,
            HalftoneMisc = 0x500E,
            HalftoneScreen = 0x500F,
            JPEGQuality = 0x5010,
            GridSize = 0x5011,
            ThumbnailFormat = 0x5012,
            ThumbnailWidth = 0x5013,
            ThumbnailHeight = 0x5014,
            ThumbnailColorDepth = 0x5015,
            ThumbnailPlanes = 0x5016,
            ThumbnailRawBytes = 0x5017,
            ThumbnailSize = 0x5018,
            ThumbnailCompressedSize = 0x5019,
            ColorTransferFunction = 0x501A,
            ThumbnailData = 0x501B,
            ThumbnailImageWidth = 0x5020,
            ThumbnailImageHeight = 0x502,
            ThumbnailBitsPerSample = 0x5022,
            ThumbnailCompression = 0x5023,
            ThumbnailPhotometricInterp = 0x5024,
            ThumbnailImageDescription = 0x5025,
            ThumbnailEquipMake = 0x5026,
            ThumbnailEquipModel = 0x5027,
            ThumbnailStripOffsets = 0x5028,
            ThumbnailOrientation = 0x5029,
            ThumbnailSamplesPerPixel = 0x502A,
            ThumbnailRowsPerStrip = 0x502B,
            ThumbnailStripBytesCount = 0x502C,
            ThumbnailResolutionX = 0x502D,
            ThumbnailResolutionY = 0x502E,
            ThumbnailPlanarConfig = 0x502F,
            ThumbnailResolutionUnit = 0x5030,
            ThumbnailTransferFunction = 0x5031,
            ThumbnailSoftwareUsed = 0x5032,
            ThumbnailDateTime = 0x5033,
            ThumbnailArtist = 0x5034,
            ThumbnailWhitePoint = 0x5035,
            ThumbnailPrimaryChromaticities = 0x5036,
            ThumbnailYCbCrCoefficients = 0x5037,
            ThumbnailYCbCrSubsampling = 0x5038,
            ThumbnailYCbCrPositioning = 0x5039,
            ThumbnailRefBlackWhite = 0x503A,
            ThumbnailCopyRight = 0x503B,
            LuminanceTable = 0x5090,
            ChrominanceTable = 0x5091,
            FrameDelay = 0x5100,
            LoopCount = 0x5101,
            PixelUnit = 0x5110,
            PixelPerUnitX = 0x5111,
            PixelPerUnitY = 0x5112,
            PaletteHistogram = 0x5113,

            Copyright = 0x8298,
            ExifExposureTime = 0x829A,
            ExifFNumber = 0x829D,
            ExifIFD = 0x8769,
            ICCProfile = 0x8773,
            ExifExposureProg = 0x8822,
            ExifSpectralSense = 0x8824,
            GpsIFD = 0x8825,
            ExifISOSpeed = 0x8827,
            ExifOECF = 0x8828,

            ExifVer = 0x9000,
            ExifDTOrig = 0x9003,
            ExifDTDigitized = 0x9004,
            ExifCompConfig = 0x9101,
            ExifCompBPP = 0x9102,
            ExifShutterSpeed = 0x9201,
            ExifAperture = 0x9202,
            ExifBrightness = 0x9203,
            ExifExposureBias = 0x9204,
            ExifMaxAperture = 0x9205,
            ExifSubjectDist = 0x9206,
            ExifMeteringMode = 0x9207,
            ExifLightSource = 0x9208,
            ExifFlash = 0x9209,
            ExifFocalLength = 0x920A,
            ExifMakerNote = 0x927C,
            ExifUserComment = 0x9286,
            ExifDTSubsec = 0x9290,
            ExifDTOrigSS = 0x9291,
            ExifDTDigSS = 0x9292,

            ExifFPXVer = 0xA000,
            ExifColorSpace = 0xA001,
            ExifPixXDim = 0xA002,
            ExifPixYDim = 0xA003,
            ExifRelatedWav = 0xA004,
            ExifInterop = 0xA005,
            ExifFlashEnergy = 0xA20B,
            ExifSpatialFR = 0xA20C,
            ExifFocalXRes = 0xA20E,
            ExifFocalYRes = 0xA20F,
            ExifFocalResUnit = 0xA210,
            ExifSubjectLoc = 0xA214,
            ExifExposureIndex = 0xA215,
            ExifSensingMethod = 0xA217,
            ExifFileSource = 0xA300,
            ExifSceneType = 0xA301,
            ExifCfaPattern = 0xA302
        }
        #endregion //TagNames
    }
}

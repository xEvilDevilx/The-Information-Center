using System;
using System.IO;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using IC.EFDesignLib;
using IC.SDK.Base;
using IC.SDK.Base.Constants;
using IC.SDK.Base.Enums;
using IC.SDK.Interfaces.Serialization;
using IC.SDK.Serialization;

namespace IC.UnitTests
{
    [TestClass]
    public class SerializerTests
    {
        /// <summary>Do stream serialize/deserialize work</summary>
        private IStreamSerializer _streamSerializer;
        /// <summary>Do bytes array serialize/deserialize work</summary>
        private IBytesArraySerializer _bytesArraySerializer;

        /// <summary>
        /// Constructor
        /// </summary>
        public SerializerTests()
        {
            _streamSerializer = new Serializer();
            _bytesArraySerializer = new Serializer();
        }

        [TestMethod]
        public void SerializeToStreamTest()
        {
            var retailAction = new RetailAction()
            {
                CaptionID = 5,
                DateBegin = DateTime.Now,
                DateEnd = DateTime.Now,
                DescriptionID = 10,
                RetailActionID = 27,
                ActivityStatus = 2
            };
            
            var stream = new MemoryStream();
            _streamSerializer.Serialize(stream, retailAction, TcpSerializeTypes.RetailAction);
            stream.Position = 0;
            var deserializedStore = (RetailAction)_streamSerializer.Deserialize(stream, 
                BaseConstants.ServerDataLayerNamespaceName, BaseConstants.ServerDataLayerLibName);
            
            //Assert.AreEqual(deserializedStore.Caption, retailAction.Caption);
            Assert.AreEqual(deserializedStore.CaptionID, retailAction.CaptionID);
            Assert.AreEqual(deserializedStore.DateBegin, retailAction.DateBegin);
            Assert.AreEqual(deserializedStore.DateEnd, retailAction.DateEnd);
            Assert.AreEqual(deserializedStore.DescriptionID, retailAction.DescriptionID);
            Assert.AreEqual(deserializedStore.RetailActionID, retailAction.RetailActionID);
            Assert.AreEqual(deserializedStore.ActivityStatus, retailAction.ActivityStatus);
        }
        
        [TestMethod]
        public void SerializeToBytesArrayTest()
        {
            var clientInfo = new ClientInfo()
            {
                UID = "0456540",                
                MACAddress = new byte[16]
                {
                    10, 15, 5, 25, 30, 35, 10, 12, 13, 15, 14, 5, 8, 108, 95, 55
                },
                AssemblyVersion = new Version("1.5.4")
            };
            
            var bytesArray = _bytesArraySerializer.SerializeToBytesArray(clientInfo, UdpSerializeTypes.ClientInfo);
            var deserializedObject = (ClientInfo)_bytesArraySerializer.DeserializeFromBytesArray(bytesArray);
            
            Assert.AreEqual(deserializedObject.UID, clientInfo.UID);
            CollectionAssert.AreEqual(deserializedObject.MACAddress, clientInfo.MACAddress);
            Assert.AreEqual(deserializedObject.AssemblyVersion, clientInfo.AssemblyVersion);
        }
        
        [TestMethod]
        public void SerializeSimpleTypeToBytesArray()
        {
            var text = "test4Text";
            var num = 4689785;
            var guid = Guid.NewGuid();
            var isTrue = true;
            var doubleNum = 468.56;
            var decimalNum = 987.59m;
            var dateTime = DateTime.Now;
            var version = Version.Parse("1.0.5.10");
            
            var textBytesArray = _bytesArraySerializer.SerializeToBytesArray(text, UdpSerializeTypes.SimpleTypes);
            var numBytesArray = _bytesArraySerializer.SerializeToBytesArray(num, UdpSerializeTypes.SimpleTypes);
            var guidBytesArray = _bytesArraySerializer.SerializeToBytesArray(guid, UdpSerializeTypes.SimpleTypes);
            var boolBytesArray = _bytesArraySerializer.SerializeToBytesArray(isTrue, UdpSerializeTypes.SimpleTypes);
            var doubleNumBytesArray = _bytesArraySerializer.SerializeToBytesArray(doubleNum, UdpSerializeTypes.SimpleTypes);
            var decimalNumBytesArray = _bytesArraySerializer.SerializeToBytesArray(decimalNum, UdpSerializeTypes.SimpleTypes);
            var dateTimeBytesArray = _bytesArraySerializer.SerializeToBytesArray(dateTime, UdpSerializeTypes.SimpleTypes);
            var versionBytesArray = _bytesArraySerializer.SerializeToBytesArray(version, UdpSerializeTypes.SimpleTypes);

            var deserializedTextObject = _bytesArraySerializer.DeserializeFromBytesArray(textBytesArray);
            var deserializedNumObject = _bytesArraySerializer.DeserializeFromBytesArray(numBytesArray);
            var deserializedGuidObject = _bytesArraySerializer.DeserializeFromBytesArray(guidBytesArray);
            var deserializedBoolObject = _bytesArraySerializer.DeserializeFromBytesArray(boolBytesArray);
            var deserializedDoubleObject = _bytesArraySerializer.DeserializeFromBytesArray(doubleNumBytesArray);
            var deserializedDecimalObject = _bytesArraySerializer.DeserializeFromBytesArray(decimalNumBytesArray);
            var deserializedDateTimeObject = _bytesArraySerializer.DeserializeFromBytesArray(dateTimeBytesArray);
            var deserializedVersionObject = _bytesArraySerializer.DeserializeFromBytesArray(versionBytesArray);
            
            Assert.AreEqual(text, deserializedTextObject);
            Assert.AreEqual(num, deserializedNumObject);
            Assert.AreEqual(guid, deserializedGuidObject);
            Assert.AreEqual(isTrue, deserializedBoolObject);
            Assert.AreEqual(doubleNum, deserializedDoubleObject);
            Assert.AreEqual(decimalNum, deserializedDecimalObject);
            Assert.AreEqual(dateTime, deserializedDateTimeObject);
            Assert.AreEqual(version, deserializedVersionObject);
        }
    }
}
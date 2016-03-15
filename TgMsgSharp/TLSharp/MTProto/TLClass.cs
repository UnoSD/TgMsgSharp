using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using TLSharp.Core.MTProto;

public class TL
{

    public static Dictionary<uint, Type> constructors = new Dictionary<uint, Type>()
        {
            {0xc4b9f9bb, typeof (ErrorConstructor)},
            {0x7f3b18ea, typeof (InputPeerEmptyConstructor)},
            {0x7da07ec9, typeof (InputPeerSelfConstructor)},
            {0x1023dbe8, typeof (InputPeerContactConstructor)},
            {0x9b447325, typeof (InputPeerForeignConstructor)},
            {0x179be863, typeof (InputPeerChatConstructor)},
            {0xb98886cf, typeof (InputUserEmptyConstructor)},
            {0xf7c1b13f, typeof (InputUserSelfConstructor)},
            {0x86e94f65, typeof (InputUserContactConstructor)},
            {0x655e74ff, typeof (InputUserForeignConstructor)},
            {0xf392b7f4, typeof (InputPhoneContactConstructor)},
            {0xf52ff27f, typeof (InputFileConstructor)},
            {0x9664f57f, typeof (InputMediaEmptyConstructor)},
            {0x2dc53a7d, typeof (InputMediaUploadedPhotoConstructor)},
            {0x8f2ab2ec, typeof (InputMediaPhotoConstructor)},
            {0xf9c44144, typeof (InputMediaGeoPointConstructor)},
            {0xa6e45987, typeof (InputMediaContactConstructor)},
            {0x4847d92a, typeof (InputMediaUploadedVideoConstructor)},
            {0xe628a145, typeof (InputMediaUploadedThumbVideoConstructor)},
            {0x7f023ae6, typeof (InputMediaVideoConstructor)},
            {0x1ca48f57, typeof (InputChatPhotoEmptyConstructor)},
            {0x94254732, typeof (InputChatUploadedPhotoConstructor)},
            {0xb2e1bf08, typeof (InputChatPhotoConstructor)},
            {0xe4c123d6, typeof (InputGeoPointEmptyConstructor)},
            {0xf3b7acc9, typeof (InputGeoPointConstructor)},
            {0x1cd7bf0d, typeof (InputPhotoEmptyConstructor)},
            {0xfb95c6c4, typeof (InputPhotoConstructor)},
            {0x5508ec75, typeof (InputVideoEmptyConstructor)},
            {0xee579652, typeof (InputVideoConstructor)},
            {0x14637196, typeof (InputFileLocationConstructor)},
            {0x3d0364ec, typeof (InputVideoFileLocationConstructor)},
            {0xade6b004, typeof (InputPhotoCropAutoConstructor)},
            {0xd9915325, typeof (InputPhotoCropConstructor)},
            {0x770656a8, typeof (InputAppEventConstructor)},
            {0x9db1bc6d, typeof (PeerUserConstructor)},
            {0xbad0e5bb, typeof (PeerChatConstructor)},
            {0xaa963b05, typeof (Storage_fileUnknownConstructor)},
            {0x007efe0e, typeof (Storage_fileJpegConstructor)},
            {0xcae1aadf, typeof (Storage_fileGifConstructor)},
            {0x0a4f63c0, typeof (Storage_filePngConstructor)},
            {0x528a0677, typeof (Storage_fileMp3Constructor)},
            {0x4b09ebbc, typeof (Storage_fileMovConstructor)},
            {0x40bc6f52, typeof (Storage_filePartialConstructor)},
            {0xb3cea0e4, typeof (Storage_fileMp4Constructor)},
            {0x1081464c, typeof (Storage_fileWebpConstructor)},
            {0x7c596b46, typeof (FileLocationUnavailableConstructor)},
            {0x53d69076, typeof (FileLocationConstructor)},
            {0x200250ba, typeof (UserEmptyConstructor)},
            {0x720535EC, typeof (UserSelfConstructor)},
            {0x7007b451, typeof (UserSelfConstructor)},
            {0x22e8ceb0, typeof (UserRequestConstructor)},
            {0x5214c89d, typeof (UserForeignConstructor)},
            {0xb29ad7cc, typeof (UserDeletedConstructor)},
            {0x4f11bae1, typeof (UserProfilePhotoEmptyConstructor)},
            {0xd559d8c8, typeof (UserProfilePhotoConstructor)},
            {0x09d05049, typeof (UserStatusEmptyConstructor)},
            {0xedb93949, typeof (UserStatusOnlineConstructor)},
            {0x008c703f, typeof (UserStatusOfflineConstructor)},
            {0x9ba2d800, typeof (ChatEmptyConstructor)},
            {0x6e9c9bc7, typeof (ChatConstructor)},
            {0xfb0ccc41, typeof (ChatForbiddenConstructor)},
            {0x630e61be, typeof (ChatFullConstructor)},
            {0xc8d7493e, typeof (ChatParticipantConstructor)},
            {0x0fd2bb8a, typeof (ChatParticipantsForbiddenConstructor)},
            {0x7841b415, typeof (ChatParticipantsConstructor)},
            {0x37c1011c, typeof (ChatPhotoEmptyConstructor)},
            {0x6153276a, typeof (ChatPhotoConstructor)},
            {0x83e5de54, typeof (MessageEmptyConstructor)},
            {0x567699B3, typeof (MessageConstructor)},
            {0xa367e716, typeof (MessageForwardedConstructor)},
            {0x9f8d60bb, typeof (MessageServiceConstructor)},
            {0x3ded6320, typeof (MessageMediaEmptyConstructor)},
            {0xc8c45a2a, typeof (MessageMediaPhotoConstructor)},
            {0xa2d24290, typeof (MessageMediaVideoConstructor)},
            {0x56e0d474, typeof (MessageMediaGeoConstructor)},
            {0x5e7d2f39, typeof (MessageMediaContactConstructor)},
            {0x29632a36, typeof (MessageMediaUnsupportedConstructor)},
            {0xb6aef7b0, typeof (MessageActionEmptyConstructor)},
            {0xa6638b9a, typeof (MessageActionChatCreateConstructor)},
            {0xb5a1ce5a, typeof (MessageActionChatEditTitleConstructor)},
            {0x7fcb13a8, typeof (MessageActionChatEditPhotoConstructor)},
            {0x95e3fbef, typeof (MessageActionChatDeletePhotoConstructor)},
            {0x5e3cfc4b, typeof (MessageActionChatAddUserConstructor)},
            {0xb2ae9b0c, typeof (MessageActionChatDeleteUserConstructor)},
            {0x214a8cdf, typeof (DialogConstructor)},
            {0x2331b22d, typeof (PhotoEmptyConstructor)},
            {0x22b56751, typeof (PhotoConstructor)},
            {0x0e17e23c, typeof (PhotoSizeEmptyConstructor)},
            {0x77bfb61b, typeof (PhotoSizeConstructor)},
            {0xe9a734fa, typeof (PhotoCachedSizeConstructor)},
            {0xc10658a8, typeof (VideoEmptyConstructor)},
            {0x388fa391, typeof (VideoConstructor)},
            {0x1117dd5f, typeof (GeoPointEmptyConstructor)},
            {0x2049d70c, typeof (GeoPointConstructor)},
            {0xe300cc3b, typeof (Auth_checkedPhoneConstructor)},
            {0x2215bcbd, typeof (Auth_sentCodeConstructor)},
            {0xf6b673a4, typeof (Auth_authorizationConstructor)},
            {0xdf969c2d, typeof (Auth_exportedAuthorizationConstructor)},
            {0xb8bc5b0c, typeof (InputNotifyPeerConstructor)},
            {0x193b4417, typeof (InputNotifyUsersConstructor)},
            {0x4a95e84e, typeof (InputNotifyChatsConstructor)},
            {0xa429b886, typeof (InputNotifyAllConstructor)},
            {0xf03064d8, typeof (InputPeerNotifyEventsEmptyConstructor)},
            {0xe86a2c74, typeof (InputPeerNotifyEventsAllConstructor)},
            {0x46a2ce98, typeof (InputPeerNotifySettingsConstructor)},
            {0xadd53cb3, typeof (PeerNotifyEventsEmptyConstructor)},
            {0x6d1ded88, typeof (PeerNotifyEventsAllConstructor)},
            {0x70a68512, typeof (PeerNotifySettingsEmptyConstructor)},
            {0x8d5e11ee, typeof (PeerNotifySettingsConstructor)},
            {0xccb03657, typeof (WallPaperConstructor)},
            {0x771095da, typeof (UserFullConstructor)},
            {0xf911c994, typeof (ContactConstructor)},
            {0xd0028438, typeof (ImportedContactConstructor)},
            {0x561bc879, typeof (ContactBlockedConstructor)},
            {0xea879f95, typeof (ContactFoundConstructor)},
            {0x3de191a1, typeof (ContactSuggestedConstructor)},
            {0xaa77b873, typeof (ContactStatusConstructor)},
            {0x3631cf4c, typeof (ChatLocatedConstructor)},
            {0x133421f8, typeof (Contacts_foreignLinkUnknownConstructor)},
            {0xa7801f47, typeof (Contacts_foreignLinkRequestedConstructor)},
            {0x1bea8ce1, typeof (Contacts_foreignLinkMutualConstructor)},
            {0xd22a1c60, typeof (Contacts_myLinkEmptyConstructor)},
            {0x6c69efee, typeof (Contacts_myLinkRequestedConstructor)},
            {0xc240ebd9, typeof (Contacts_myLinkContactConstructor)},
            {0xeccea3f5, typeof (Contacts_linkConstructor)},
            {0x6f8b8cb2, typeof (Contacts_contactsConstructor)},
            {0xb74ba9d2, typeof (Contacts_contactsNotModifiedConstructor)},
            {0xd1cd0a4c, typeof (Contacts_importedContactsConstructor)},
            {0x1c138d15, typeof (Contacts_blockedConstructor)},
            {0x900802a1, typeof (Contacts_blockedSliceConstructor)},
            {0x0566000e, typeof (Contacts_foundConstructor)},
            {0x5649dcc5, typeof (Contacts_suggestedConstructor)},
            {0x15ba6c40, typeof (Messages_dialogsConstructor)},
            {0x71e094f3, typeof (Messages_dialogsSliceConstructor)},
            {0x8c718e87, typeof (Messages_messagesConstructor)},
            {0x0b446ae3, typeof (Messages_messagesSliceConstructor)},
            {0x3f4e0648, typeof (Messages_messageEmptyConstructor)},
            {0xff90c417, typeof (Messages_messageConstructor)},
            {0x969478bb, typeof (Messages_statedMessagesConstructor)},
            {0xd07ae726, typeof (Messages_statedMessageConstructor)},
            {0xd1f4d35c, typeof (Messages_sentMessageConstructor)},
            {0x40e9002a, typeof (Messages_chatConstructor)},
            {0x8150cbd8, typeof (Messages_chatsConstructor)},
            {0xe5d7d19c, typeof (Messages_chatFullConstructor)},
            {0xb7de36f2, typeof (Messages_affectedHistoryConstructor)},
            {0x57e2f66c, typeof (InputMessagesFilterEmptyConstructor)},
            {0x9609a51c, typeof (InputMessagesFilterPhotosConstructor)},
            {0x9fc00e65, typeof (InputMessagesFilterVideoConstructor)},
            {0x56e9f0e4, typeof (InputMessagesFilterPhotoVideoConstructor)},
            {0x013abdb3, typeof (UpdateNewMessageConstructor)},
            {0x4e90bfd6, typeof (UpdateMessageIDConstructor)},
            {0xc6649e31, typeof (UpdateReadMessagesConstructor)},
            {0xa92bfe26, typeof (UpdateDeleteMessagesConstructor)},
            {0xd15de04d, typeof (UpdateRestoreMessagesConstructor)},
            {0x6baa8508, typeof (UpdateUserTypingConstructor)},
            {0x3c46cfe6, typeof (UpdateChatUserTypingConstructor)},
            {0x07761198, typeof (UpdateChatParticipantsConstructor)},
            {0x1bfbd823, typeof (UpdateUserStatusConstructor)},
            {0xda22d9ad, typeof (UpdateUserNameConstructor)},
            {0x95313b0c, typeof (UpdateUserPhotoConstructor)},
            {0x2575bbb9, typeof (UpdateContactRegisteredConstructor)},
            {0x51a48a9a, typeof (UpdateContactLinkConstructor)},
            {0x6f690963, typeof (UpdateActivationConstructor)},
            {0x8f06529a, typeof (UpdateNewAuthorizationConstructor)},
            {0xa56c2a3e, typeof (Updates_stateConstructor)},
            {0x5d75a138, typeof (Updates_differenceEmptyConstructor)},
            {0x00f49ca0, typeof (Updates_differenceConstructor)},
            {0xa8fb1981, typeof (Updates_differenceSliceConstructor)},
            {0xe317af7e, typeof (UpdatesTooLongConstructor)},
            {0xd3f45784, typeof (UpdateShortMessageConstructor)},
            {0x2b2fbd4e, typeof (UpdateShortChatMessageConstructor)},
            {0x78d4dec1, typeof (UpdateShortConstructor)},
            {0x725b04c3, typeof (UpdatesCombinedConstructor)},
            {0x74ae4240, typeof (UpdatesConstructor)},
            {0x8dca6aa5, typeof (Photos_photosConstructor)},
            {0x15051f54, typeof (Photos_photosSliceConstructor)},
            {0x20212ca8, typeof (Photos_photoConstructor)},
            {0x096a18d5, typeof (Upload_fileConstructor)},
            {0x2ec2a43c, typeof (DcOptionConstructor)},
            {0x232d5905, typeof (ConfigConstructor)},
            {0x7DAE33E0, typeof (ConfigConstructor)},
            {0x8e1a1775, typeof (NearestDcConstructor)},
            {0x8987f311, typeof (Help_appUpdateConstructor)},
            {0xc45a6536, typeof (Help_noAppUpdateConstructor)},
            {0x18cb9f78, typeof (Help_inviteTextConstructor)},
            {0x3e74f5c6, typeof (Messages_statedMessagesLinksConstructor)},
            {0xa9af2881, typeof (Messages_statedMessageLinkConstructor)},
            {0xe9db4a3f, typeof (Messages_sentMessageLinkConstructor)},
            {0x74d456fa, typeof (InputGeoChatConstructor)},
            {0x4d8ddec8, typeof (InputNotifyGeoChatPeerConstructor)},
            {0x75eaea5a, typeof (GeoChatConstructor)},
            {0x60311a9b, typeof (GeoChatMessageEmptyConstructor)},
            {0x4505f8e1, typeof (GeoChatMessageConstructor)},
            {0xd34fa24e, typeof (GeoChatMessageServiceConstructor)},
            {0x17b1578b, typeof (Geochats_statedMessageConstructor)},
            {0x48feb267, typeof (Geochats_locatedConstructor)},
            {0xd1526db1, typeof (Geochats_messagesConstructor)},
            {0xbc5863e8, typeof (Geochats_messagesSliceConstructor)},
            {0x6f038ebc, typeof (MessageActionGeoChatCreateConstructor)},
            {0x0c7d53de, typeof (MessageActionGeoChatCheckinConstructor)},
            {0x5a68e3f7, typeof (UpdateNewGeoChatMessageConstructor)},
            {0x63117f24, typeof (WallPaperSolidConstructor)},
            {0x12bcbd9a, typeof (UpdateNewEncryptedMessageConstructor)},
            {0x1710f156, typeof (UpdateEncryptedChatTypingConstructor)},
            {0xb4a2e88d, typeof (UpdateEncryptionConstructor)},
            {0x38fe25b7, typeof (UpdateEncryptedMessagesReadConstructor)},
            {0xab7ec0a0, typeof (EncryptedChatEmptyConstructor)},
            {0x3bf703dc, typeof (EncryptedChatWaitingConstructor)},
            {0xfda9a7b7, typeof (EncryptedChatRequestedConstructor)},
            {0x6601d14f, typeof (EncryptedChatConstructor)},
            {0x13d6dd27, typeof (EncryptedChatDiscardedConstructor)},
            {0xf141b5e1, typeof (InputEncryptedChatConstructor)},
            {0xc21f497e, typeof (EncryptedFileEmptyConstructor)},
            {0x4a70994c, typeof (EncryptedFileConstructor)},
            {0x1837c364, typeof (InputEncryptedFileEmptyConstructor)},
            {0x64bd0306, typeof (InputEncryptedFileUploadedConstructor)},
            {0x5a17b5e5, typeof (InputEncryptedFileConstructor)},
            {0xf5235d55, typeof (InputEncryptedFileLocationConstructor)},
            {0xed18c118, typeof (EncryptedMessageConstructor)},
            {0x23734b06, typeof (EncryptedMessageServiceConstructor)},
            {0x99a438cf, typeof (DecryptedMessageLayerConstructor)},
            {0x1f814f1f, typeof (DecryptedMessageConstructor)},
            {0xaa48327d, typeof (DecryptedMessageServiceConstructor)},
            {0x089f5c4a, typeof (DecryptedMessageMediaEmptyConstructor)},
            {0x32798a8c, typeof (DecryptedMessageMediaPhotoConstructor)},
            {0x4cee6ef3, typeof (DecryptedMessageMediaVideoConstructor)},
            {0x35480a59, typeof (DecryptedMessageMediaGeoPointConstructor)},
            {0x588a0a97, typeof (DecryptedMessageMediaContactConstructor)},
            {0xa1733aec, typeof (DecryptedMessageActionSetMessageTTLConstructor)},
            {0xc0e24635, typeof (Messages_dhConfigNotModifiedConstructor)},
            {0x2c221edd, typeof (Messages_dhConfigConstructor)},
            {0x560f8935, typeof (Messages_sentEncryptedMessageConstructor)},
            {0x9493ff32, typeof (Messages_sentEncryptedFileConstructor)},
            {0xfa4f0bb5, typeof (InputFileBigConstructor)},
            {0x2dc173c8, typeof (InputEncryptedFileBigUploadedConstructor)},
            {0x3a0eeb22, typeof (UpdateChatParticipantAddConstructor)},
            {0x6e5f8c22, typeof (UpdateChatParticipantDeleteConstructor)},
            {0x8e5e9873, typeof (UpdateDcOptionsConstructor)},
            {0x61a6d436, typeof (InputMediaUploadedAudioConstructor)},
            {0x89938781, typeof (InputMediaAudioConstructor)},
            {0x34e794bd, typeof (InputMediaUploadedDocumentConstructor)},
            {0x3e46de5d, typeof (InputMediaUploadedThumbDocumentConstructor)},
            {0xd184e841, typeof (InputMediaDocumentConstructor)},
            {0x2fda2204  , typeof (MessageMediaDocumentConstructor)},
            {0xc6b68300, typeof (MessageMediaAudioConstructor)},
            {0xd95adc84, typeof (InputAudioEmptyConstructor)},
            {0x77d440ff, typeof (InputAudioConstructor)},
            {0x72f0eaae, typeof (InputDocumentEmptyConstructor)},
            {0x18798952, typeof (InputDocumentConstructor)},
            {0x74dc404d, typeof (InputAudioFileLocationConstructor)},
            {0x4e45abe9, typeof (InputDocumentFileLocationConstructor)},
            {0xb095434b, typeof (DecryptedMessageMediaDocumentConstructor)},
            {0x6080758f, typeof (DecryptedMessageMediaAudioConstructor)},
            {0x586988d8, typeof (AudioEmptyConstructor)},
            {0xc7ac6496, typeof (AudioConstructor)},
            {0x36f8c871, typeof (DocumentEmptyConstructor)},
            {0xf9a39f4f, typeof (DocumentConstructor)},
        };

    static readonly TlObjectReadersFactory _tlObjectReadersFactory = new TlObjectReadersFactory();
    static IReadOnlyCollection<Type> _cachedTypes;

    public static TLObject Parse(BinaryReader reader, uint code)
    {
        if (!constructors.ContainsKey(code))
        {
            throw new Exception("unknown constructor code");
        }

        uint dataCode = reader.ReadUInt32();
        if (dataCode != code)
        {
            throw new Exception(String.Format("target code {0} != data code {1}", code, dataCode));
        }

        TLObject obj = (TLObject)Activator.CreateInstance(constructors[code]);
        obj.Read(reader);
        return obj;
    }

    public static T Parse<T>(BinaryReader reader)
    {
        if (typeof(TLObject).IsAssignableFrom(typeof(T)))
        {
            var dataCode = reader.ReadUInt32();

            var hexDataCode = new Combinator(dataCode);

            if (!typeof(T).IsAssignableFrom(hexDataCode.ToType))
            {
                Debugger.Break();

                throw new Exception($"try to parse {typeof(T).FullName}, but incompatible type {hexDataCode.ToType.FullName}");
            }

            T obj;

            var objectReader = _tlObjectReadersFactory.GetReader(hexDataCode.ToType);

            if (objectReader != null)
                obj = objectReader.Read<T>(reader, hexDataCode.ToType);
            else
            {
                obj = (T)Activator.CreateInstance(hexDataCode.ToType);

                ((TLObject)(object)obj).Read(reader);
            }

            return obj;
        }

        if (typeof(T) != typeof(bool)) throw new Exception("unknown return type");

        var code = reader.ReadUInt32();

        switch (code)
        {
            case 0x997275b5:
                return (T)(object)true;
            case 0xbc799737:
                return (T)(object)false;
            default:
                throw new Exception("unknown bool value");
        }
    }

    //public delegate TLObject InputPeerContactDelegate(InputPeerContactConstructor x);
    // constructors

    public static Error error(int code, string text)
    {
        return new ErrorConstructor(code, text);
    }

    public static InputPeer inputPeerEmpty()
    {
        return new InputPeerEmptyConstructor();
    }

    public static InputPeer inputPeerSelf()
    {
        return new InputPeerSelfConstructor();
    }

    public static InputPeer inputPeerContact(int user_id)
    {
        return new InputPeerContactConstructor(user_id);
    }

    public static InputPeer inputPeerForeign(int user_id, long access_hash)
    {
        return new InputPeerForeignConstructor(user_id, access_hash);
    }

    public static InputPeer inputPeerChat(int chat_id)
    {
        return new InputPeerChatConstructor(chat_id);
    }

    public static InputUser inputUserEmpty()
    {
        return new InputUserEmptyConstructor();
    }

    public static InputUser inputUserSelf()
    {
        return new InputUserSelfConstructor();
    }

    public static InputUser inputUserContact(int user_id)
    {
        return new InputUserContactConstructor(user_id);
    }

    public static InputUser inputUserForeign(int user_id, long access_hash)
    {
        return new InputUserForeignConstructor(user_id, access_hash);
    }

    public static InputContact inputPhoneContact(long client_id, string phone, string first_name, string last_name)
    {
        return new InputPhoneContactConstructor(client_id, phone, first_name, last_name);
    }

    public static InputFile inputFile(long id, int parts, string name, string md5_checksum)
    {
        return new InputFileConstructor(id, parts, name, md5_checksum);
    }

    public static InputMedia inputMediaEmpty()
    {
        return new InputMediaEmptyConstructor();
    }

    public static InputMedia inputMediaUploadedPhoto(InputFile file)
    {
        return new InputMediaUploadedPhotoConstructor(file);
    }

    public static InputMedia inputMediaPhoto(InputPhoto id)
    {
        return new InputMediaPhotoConstructor(id);
    }

    public static InputMedia inputMediaGeoPoint(InputGeoPoint geo_point)
    {
        return new InputMediaGeoPointConstructor(geo_point);
    }

    public static InputMedia inputMediaContact(string phone_number, string first_name, string last_name)
    {
        return new InputMediaContactConstructor(phone_number, first_name, last_name);
    }

    public static InputMedia inputMediaUploadedVideo(InputFile file, int duration, int w, int h)
    {
        return new InputMediaUploadedVideoConstructor(file, duration, w, h);
    }

    public static InputMedia inputMediaUploadedThumbVideo(InputFile file, InputFile thumb, int duration, int w, int h)
    {
        return new InputMediaUploadedThumbVideoConstructor(file, thumb, duration, w, h);
    }

    public static InputMedia inputMediaVideo(InputVideo id)
    {
        return new InputMediaVideoConstructor(id);
    }

    public static InputChatPhoto inputChatPhotoEmpty()
    {
        return new InputChatPhotoEmptyConstructor();
    }

    public static InputChatPhoto inputChatUploadedPhoto(InputFile file, InputPhotoCrop crop)
    {
        return new InputChatUploadedPhotoConstructor(file, crop);
    }

    public static InputChatPhoto inputChatPhoto(InputPhoto id, InputPhotoCrop crop)
    {
        return new InputChatPhotoConstructor(id, crop);
    }

    public static InputGeoPoint inputGeoPointEmpty()
    {
        return new InputGeoPointEmptyConstructor();
    }

    public static InputGeoPoint inputGeoPoint(double lat, double lng)
    {
        return new InputGeoPointConstructor(lat, lng);
    }

    public static InputPhoto inputPhotoEmpty()
    {
        return new InputPhotoEmptyConstructor();
    }

    public static InputPhoto inputPhoto(long id, long access_hash)
    {
        return new InputPhotoConstructor(id, access_hash);
    }

    public static InputVideo inputVideoEmpty()
    {
        return new InputVideoEmptyConstructor();
    }

    public static InputVideo inputVideo(long id, long access_hash)
    {
        return new InputVideoConstructor(id, access_hash);
    }

    public static InputFileLocation inputFileLocation(long volume_id, int local_id, long secret)
    {
        return new InputFileLocationConstructor(volume_id, local_id, secret);
    }

    public static InputFileLocation inputVideoFileLocation(long id, long access_hash)
    {
        return new InputVideoFileLocationConstructor(id, access_hash);
    }

    public static InputPhotoCrop inputPhotoCropAuto()
    {
        return new InputPhotoCropAutoConstructor();
    }

    public static InputPhotoCrop inputPhotoCrop(double crop_left, double crop_top, double crop_width)
    {
        return new InputPhotoCropConstructor(crop_left, crop_top, crop_width);
    }

    public static InputAppEvent inputAppEvent(double time, string type, long peer, string data)
    {
        return new InputAppEventConstructor(time, type, peer, data);
    }

    public static Peer peerUser(int user_id)
    {
        return new PeerUserConstructor(user_id);
    }

    public static Peer peerChat(int chat_id)
    {
        return new PeerChatConstructor(chat_id);
    }

    public static storage_FileType storage_fileUnknown()
    {
        return new Storage_fileUnknownConstructor();
    }

    public static storage_FileType storage_fileJpeg()
    {
        return new Storage_fileJpegConstructor();
    }

    public static storage_FileType storage_fileGif()
    {
        return new Storage_fileGifConstructor();
    }

    public static storage_FileType storage_filePng()
    {
        return new Storage_filePngConstructor();
    }

    public static storage_FileType storage_fileMp3()
    {
        return new Storage_fileMp3Constructor();
    }

    public static storage_FileType storage_fileMov()
    {
        return new Storage_fileMovConstructor();
    }

    public static storage_FileType storage_filePartial()
    {
        return new Storage_filePartialConstructor();
    }

    public static storage_FileType storage_fileMp4()
    {
        return new Storage_fileMp4Constructor();
    }

    public static storage_FileType storage_fileWebp()
    {
        return new Storage_fileWebpConstructor();
    }

    public static FileLocation fileLocationUnavailable(long volume_id, int local_id, long secret)
    {
        return new FileLocationUnavailableConstructor(volume_id, local_id, secret);
    }

    public static FileLocation fileLocation(int dc_id, long volume_id, int local_id, long secret)
    {
        return new FileLocationConstructor(dc_id, volume_id, local_id, secret);
    }

    public static User userEmpty(int id)
    {
        return new UserEmptyConstructor(id);
    }

    public static User userSelf(int id, string first_name, string last_name, string phone, UserProfilePhoto photo,
        UserStatus status, bool inactive)
    {
        return new UserSelfConstructor(id, first_name, last_name, phone, photo, status, inactive);
    }

    public static User userRequest(int id, string first_name, string last_name, long access_hash, string phone,
        UserProfilePhoto photo, UserStatus status)
    {
        return new UserRequestConstructor(id, first_name, last_name, access_hash, phone, photo, status);
    }

    public static User userForeign(int id, string first_name, string last_name, long access_hash, UserProfilePhoto photo,
        UserStatus status)
    {
        return new UserForeignConstructor(id, first_name, last_name, access_hash, photo, status);
    }

    public static User userDeleted(int id, string first_name, string last_name)
    {
        return new UserDeletedConstructor(id, first_name, last_name);
    }

    public static UserProfilePhoto userProfilePhotoEmpty()
    {
        return new UserProfilePhotoEmptyConstructor();
    }

    public static UserProfilePhoto userProfilePhoto(long photo_id, FileLocation photo_small, FileLocation photo_big)
    {
        return new UserProfilePhotoConstructor(photo_id, photo_small, photo_big);
    }

    public static UserStatus userStatusEmpty()
    {
        return new UserStatusEmptyConstructor();
    }

    public static UserStatus userStatusOnline(int expires)
    {
        return new UserStatusOnlineConstructor(expires);
    }

    public static UserStatus userStatusOffline(int was_online)
    {
        return new UserStatusOfflineConstructor(was_online);
    }

    public static Chat chatEmpty(int id)
    {
        return new ChatEmptyConstructor(id);
    }

    public static Chat chat(int id, string title, ChatPhoto photo, int participants_count, int date, bool left,
        int version)
    {
        return new ChatConstructor(id, title, photo, participants_count, date, left, version);
    }

    public static Chat chatForbidden(int id, string title, int date)
    {
        return new ChatForbiddenConstructor(id, title, date);
    }

    public static ChatFull chatFull(int id, ChatParticipants participants, Photo chat_photo,
        PeerNotifySettings notify_settings)
    {
        return new ChatFullConstructor(id, participants, chat_photo, notify_settings);
    }

    public static ChatParticipant chatParticipant(int user_id, int inviter_id, int date)
    {
        return new ChatParticipantConstructor(user_id, inviter_id, date);
    }

    public static ChatParticipants chatParticipantsForbidden(int chat_id)
    {
        return new ChatParticipantsForbiddenConstructor(chat_id);
    }

    public static ChatParticipants chatParticipants(int chat_id, int admin_id, List<ChatParticipant> participants,
        int version)
    {
        return new ChatParticipantsConstructor(chat_id, admin_id, participants, version);
    }

    public static ChatPhoto chatPhotoEmpty()
    {
        return new ChatPhotoEmptyConstructor();
    }

    public static ChatPhoto chatPhoto(FileLocation photo_small, FileLocation photo_big)
    {
        return new ChatPhotoConstructor(photo_small, photo_big);
    }

    public static Message messageEmpty(int id)
    {
        return new MessageEmptyConstructor(id);
    }

    public static Message messageForwarded(int id, int fwd_from_id, int fwd_date, int from_id, int to_id, bool output,
        bool unread, int date, string message, MessageMedia media)
    {
        return new MessageForwardedConstructor(id, fwd_from_id, fwd_date, from_id, to_id, output, unread, date, message,
            media);
    }

    public static Message messageService(int id, int from_id, Peer to_id, bool output, bool unread, int date,
        MessageAction action)
    {
        return new MessageServiceConstructor(id, from_id, to_id, output, unread, date, action);
    }

    public static MessageMedia messageMediaEmpty()
    {
        return new MessageMediaEmptyConstructor();
    }

    public static MessageMedia messageMediaPhoto(Photo photo)
    {
        return new MessageMediaPhotoConstructor(photo);
    }

    public static MessageMedia messageMediaVideo(Video video)
    {
        return new MessageMediaVideoConstructor(video);
    }

    public static MessageMedia messageMediaGeo(GeoPoint geo)
    {
        return new MessageMediaGeoConstructor(geo);
    }

    public static MessageMedia messageMediaContact(string phone_number, string first_name, string last_name, int user_id)
    {
        return new MessageMediaContactConstructor(phone_number, first_name, last_name, user_id);
    }

    public static MessageMedia messageMediaUnsupported(byte[] bytes)
    {
        return new MessageMediaUnsupportedConstructor(bytes);
    }

    public static MessageAction messageActionEmpty()
    {
        return new MessageActionEmptyConstructor();
    }

    public static MessageAction messageActionChatCreate(string title, List<int> users)
    {
        return new MessageActionChatCreateConstructor(title, users);
    }

    public static MessageAction messageActionChatEditTitle(string title)
    {
        return new MessageActionChatEditTitleConstructor(title);
    }

    public static MessageAction messageActionChatEditPhoto(Photo photo)
    {
        return new MessageActionChatEditPhotoConstructor(photo);
    }

    public static MessageAction messageActionChatDeletePhoto()
    {
        return new MessageActionChatDeletePhotoConstructor();
    }

    public static MessageAction messageActionChatAddUser(int user_id)
    {
        return new MessageActionChatAddUserConstructor(user_id);
    }

    public static MessageAction messageActionChatDeleteUser(int user_id)
    {
        return new MessageActionChatDeleteUserConstructor(user_id);
    }

    public static Dialog dialog(Peer peer, int top_message, int unread_count)
    {
        return new DialogConstructor(peer, top_message, unread_count);
    }

    public static Photo photoEmpty(long id)
    {
        return new PhotoEmptyConstructor(id);
    }

    public static Photo photo(long id, long access_hash, int user_id, int date, string caption, GeoPoint geo,
        List<PhotoSize> sizes)
    {
        return new PhotoConstructor(id, access_hash, user_id, date, caption, geo, sizes);
    }

    public static PhotoSize photoSizeEmpty(string type)
    {
        return new PhotoSizeEmptyConstructor(type);
    }

    public static PhotoSize photoSize(string type, FileLocation location, int w, int h, int size)
    {
        return new PhotoSizeConstructor(type, location, w, h, size);
    }

    public static PhotoSize photoCachedSize(string type, FileLocation location, int w, int h, byte[] bytes)
    {
        return new PhotoCachedSizeConstructor(type, location, w, h, bytes);
    }

    public static Video videoEmpty(long id)
    {
        return new VideoEmptyConstructor(id);
    }

    public static Video video(long id, long access_hash, int user_id, int date, string caption, int duration, int size,
        PhotoSize thumb, int dc_id, int w, int h)
    {
        return new VideoConstructor(id, access_hash, user_id, date, caption, duration, size, thumb, dc_id, w, h);
    }

    public static GeoPoint geoPointEmpty()
    {
        return new GeoPointEmptyConstructor();
    }

    public static GeoPoint geoPoint(double lng, double lat)
    {
        return new GeoPointConstructor(lng, lat);
    }

    public static auth_CheckedPhone auth_checkedPhone(bool phone_registered, bool phone_invited)
    {
        return new Auth_checkedPhoneConstructor(phone_registered, phone_invited);
    }

    public static auth_SentCode auth_sentCode(bool phone_registered, string phone_code_hash)
    {
        return new Auth_sentCodeConstructor(phone_registered, phone_code_hash);
    }

    public static auth_Authorization auth_authorization(int expires, User user)
    {
        return new Auth_authorizationConstructor(expires, user);
    }

    public static auth_ExportedAuthorization auth_exportedAuthorization(int id, byte[] bytes)
    {
        return new Auth_exportedAuthorizationConstructor(id, bytes);
    }

    public static InputNotifyPeer inputNotifyPeer(InputPeer peer)
    {
        return new InputNotifyPeerConstructor(peer);
    }

    public static InputNotifyPeer inputNotifyUsers()
    {
        return new InputNotifyUsersConstructor();
    }

    public static InputNotifyPeer inputNotifyChats()
    {
        return new InputNotifyChatsConstructor();
    }

    public static InputNotifyPeer inputNotifyAll()
    {
        return new InputNotifyAllConstructor();
    }

    public static InputPeerNotifyEvents inputPeerNotifyEventsEmpty()
    {
        return new InputPeerNotifyEventsEmptyConstructor();
    }

    public static InputPeerNotifyEvents inputPeerNotifyEventsAll()
    {
        return new InputPeerNotifyEventsAllConstructor();
    }

    public static InputPeerNotifySettings inputPeerNotifySettings(int mute_until, string sound, bool show_previews,
        int events_mask)
    {
        return new InputPeerNotifySettingsConstructor(mute_until, sound, show_previews, events_mask);
    }

    public static PeerNotifyEvents peerNotifyEventsEmpty()
    {
        return new PeerNotifyEventsEmptyConstructor();
    }

    public static PeerNotifyEvents peerNotifyEventsAll()
    {
        return new PeerNotifyEventsAllConstructor();
    }

    public static PeerNotifySettings peerNotifySettingsEmpty()
    {
        return new PeerNotifySettingsEmptyConstructor();
    }

    public static PeerNotifySettings peerNotifySettings(int mute_until, string sound, bool show_previews, int events_mask)
    {
        return new PeerNotifySettingsConstructor(mute_until, sound, show_previews, events_mask);
    }

    public static WallPaper wallPaper(int id, string title, List<PhotoSize> sizes, int color)
    {
        return new WallPaperConstructor(id, title, sizes, color);
    }

    public static UserFull userFull(User user, contacts_Link link, Photo profile_photo, PeerNotifySettings notify_settings,
        bool blocked, string real_first_name, string real_last_name)
    {
        return new UserFullConstructor(user, link, profile_photo, notify_settings, blocked, real_first_name, real_last_name);
    }

    public static Contact contact(int user_id, bool mutual)
    {
        return new ContactConstructor(user_id, mutual);
    }

    public static ImportedContact importedContact(int user_id, long client_id)
    {
        return new ImportedContactConstructor(user_id, client_id);
    }

    public static ContactBlocked contactBlocked(int user_id, int date)
    {
        return new ContactBlockedConstructor(user_id, date);
    }

    public static ContactFound contactFound(int user_id)
    {
        return new ContactFoundConstructor(user_id);
    }

    public static ContactSuggested contactSuggested(int user_id, int mutual_contacts)
    {
        return new ContactSuggestedConstructor(user_id, mutual_contacts);
    }

    public static ContactStatus contactStatus(int user_id, int expires)
    {
        return new ContactStatusConstructor(user_id, expires);
    }

    public static ChatLocated chatLocated(int chat_id, int distance)
    {
        return new ChatLocatedConstructor(chat_id, distance);
    }

    public static contacts_ForeignLink contacts_foreignLinkUnknown()
    {
        return new Contacts_foreignLinkUnknownConstructor();
    }

    public static contacts_ForeignLink contacts_foreignLinkRequested(bool has_phone)
    {
        return new Contacts_foreignLinkRequestedConstructor(has_phone);
    }

    public static contacts_ForeignLink contacts_foreignLinkMutual()
    {
        return new Contacts_foreignLinkMutualConstructor();
    }

    public static contacts_MyLink contacts_myLinkEmpty()
    {
        return new Contacts_myLinkEmptyConstructor();
    }

    public static contacts_MyLink contacts_myLinkRequested(bool contact)
    {
        return new Contacts_myLinkRequestedConstructor(contact);
    }

    public static contacts_MyLink contacts_myLinkContact()
    {
        return new Contacts_myLinkContactConstructor();
    }

    public static contacts_Link contacts_link(contacts_MyLink my_link, contacts_ForeignLink foreign_link, User user)
    {
        return new Contacts_linkConstructor(my_link, foreign_link, user);
    }

    public static contacts_Contacts contacts_contacts(List<Contact> contacts, List<User> users)
    {
        return new Contacts_contactsConstructor(contacts, users);
    }

    public static contacts_Contacts contacts_contactsNotModified()
    {
        return new Contacts_contactsNotModifiedConstructor();
    }

    public static contacts_ImportedContacts contacts_importedContacts(List<ImportedContact> imported, List<User> users)
    {
        return new Contacts_importedContactsConstructor(imported, users);
    }

    public static contacts_Blocked contacts_blocked(List<ContactBlocked> blocked, List<User> users)
    {
        return new Contacts_blockedConstructor(blocked, users);
    }

    public static contacts_Blocked contacts_blockedSlice(int count, List<ContactBlocked> blocked, List<User> users)
    {
        return new Contacts_blockedSliceConstructor(count, blocked, users);
    }

    public static contacts_Found contacts_found(List<ContactFound> results, List<User> users)
    {
        return new Contacts_foundConstructor(results, users);
    }

    public static contacts_Suggested contacts_suggested(List<ContactSuggested> results, List<User> users)
    {
        return new Contacts_suggestedConstructor(results, users);
    }

    public static messages_Dialogs messages_dialogs(List<Dialog> dialogs, List<Message> messages, List<Chat> chats,
        List<User> users)
    {
        return new Messages_dialogsConstructor(dialogs, messages, chats, users);
    }

    public static messages_Dialogs messages_dialogsSlice(int count, List<Dialog> dialogs, List<Message> messages,
        List<Chat> chats, List<User> users)
    {
        return new Messages_dialogsSliceConstructor(count, dialogs, messages, chats, users);
    }

    public static messages_Messages messages_messages(List<Message> messages, List<Chat> chats, List<User> users)
    {
        return new Messages_messagesConstructor(messages, chats, users);
    }

    public static messages_Messages messages_messagesSlice(int count, List<Message> messages, List<Chat> chats,
        List<User> users)
    {
        return new Messages_messagesSliceConstructor(count, messages, chats, users);
    }

    public static messages_Message messages_messageEmpty()
    {
        return new Messages_messageEmptyConstructor();
    }

    public static messages_Message messages_message(Message message, List<Chat> chats, List<User> users)
    {
        return new Messages_messageConstructor(message, chats, users);
    }

    public static messages_StatedMessages messages_statedMessages(List<Message> messages, List<Chat> chats,
        List<User> users, int pts, int seq)
    {
        return new Messages_statedMessagesConstructor(messages, chats, users, pts, seq);
    }

    public static messages_StatedMessage messages_statedMessage(Message message, List<Chat> chats, List<User> users,
        int pts, int seq)
    {
        return new Messages_statedMessageConstructor(message, chats, users, pts, seq);
    }

    public static messages_SentMessage messages_sentMessage(int id, int date, int pts, int seq)
    {
        return new Messages_sentMessageConstructor(id, date, pts, seq);
    }

    public static messages_Chat messages_chat(Chat chat, List<User> users)
    {
        return new Messages_chatConstructor(chat, users);
    }

    public static messages_Chats messages_chats(List<Chat> chats, List<User> users)
    {
        return new Messages_chatsConstructor(chats, users);
    }

    public static messages_ChatFull messages_chatFull(ChatFull full_chat, List<Chat> chats, List<User> users)
    {
        return new Messages_chatFullConstructor(full_chat, chats, users);
    }

    public static messages_AffectedHistory messages_affectedHistory(int pts, int seq, int offset)
    {
        return new Messages_affectedHistoryConstructor(pts, seq, offset);
    }

    public static MessagesFilter inputMessagesFilterEmpty()
    {
        return new InputMessagesFilterEmptyConstructor();
    }

    public static MessagesFilter inputMessagesFilterPhotos()
    {
        return new InputMessagesFilterPhotosConstructor();
    }

    public static MessagesFilter inputMessagesFilterVideo()
    {
        return new InputMessagesFilterVideoConstructor();
    }

    public static MessagesFilter inputMessagesFilterPhotoVideo()
    {
        return new InputMessagesFilterPhotoVideoConstructor();
    }

    public static Update updateNewMessage(Message message, int pts)
    {
        return new UpdateNewMessageConstructor(message, pts);
    }

    public static Update updateMessageID(int id, long random_id)
    {
        return new UpdateMessageIDConstructor(id, random_id);
    }

    public static Update updateReadMessages(List<int> messages, int pts)
    {
        return new UpdateReadMessagesConstructor(messages, pts);
    }

    public static Update updateDeleteMessages(List<int> messages, int pts)
    {
        return new UpdateDeleteMessagesConstructor(messages, pts);
    }

    public static Update updateRestoreMessages(List<int> messages, int pts)
    {
        return new UpdateRestoreMessagesConstructor(messages, pts);
    }

    public static Update updateUserTyping(int user_id)
    {
        return new UpdateUserTypingConstructor(user_id);
    }

    public static Update updateChatUserTyping(int chat_id, int user_id)
    {
        return new UpdateChatUserTypingConstructor(chat_id, user_id);
    }

    public static Update updateChatParticipants(ChatParticipants participants)
    {
        return new UpdateChatParticipantsConstructor(participants);
    }

    public static Update updateUserStatus(int user_id, UserStatus status)
    {
        return new UpdateUserStatusConstructor(user_id, status);
    }

    public static Update updateUserName(int user_id, string first_name, string last_name)
    {
        return new UpdateUserNameConstructor(user_id, first_name, last_name);
    }

    public static Update updateUserPhoto(int user_id, int date, UserProfilePhoto photo, bool previous)
    {
        return new UpdateUserPhotoConstructor(user_id, date, photo, previous);
    }

    public static Update updateContactRegistered(int user_id, int date)
    {
        return new UpdateContactRegisteredConstructor(user_id, date);
    }

    public static Update updateContactLink(int user_id, contacts_MyLink my_link, contacts_ForeignLink foreign_link)
    {
        return new UpdateContactLinkConstructor(user_id, my_link, foreign_link);
    }

    public static Update updateActivation(int user_id)
    {
        return new UpdateActivationConstructor(user_id);
    }

    public static Update updateNewAuthorization(long auth_key_id, int date, string device, string location)
    {
        return new UpdateNewAuthorizationConstructor(auth_key_id, date, device, location);
    }

    public static updates_State updates_state(int pts, int qts, int date, int seq, int unread_count)
    {
        return new Updates_stateConstructor(pts, qts, date, seq, unread_count);
    }

    public static updates_Difference updates_differenceEmpty(int date, int seq)
    {
        return new Updates_differenceEmptyConstructor(date, seq);
    }

    public static updates_Difference updates_difference(List<Message> new_messages,
        List<EncryptedMessage> new_encrypted_messages, List<Update> other_updates, List<Chat> chats, List<User> users,
        updates_State state)
    {
        return new Updates_differenceConstructor(new_messages, new_encrypted_messages, other_updates, chats, users, state);
    }

    public static updates_Difference updates_differenceSlice(List<Message> new_messages,
        List<EncryptedMessage> new_encrypted_messages, List<Update> other_updates, List<Chat> chats, List<User> users,
        updates_State intermediate_state)
    {
        return new Updates_differenceSliceConstructor(new_messages, new_encrypted_messages, other_updates, chats, users,
            intermediate_state);
    }

    public static Updates updatesTooLong()
    {
        return new UpdatesTooLongConstructor();
    }

    public static Updates updateShortMessage(int id, int from_id, string message, int pts, int date, int seq)
    {
        return new UpdateShortMessageConstructor(id, from_id, message, pts, date, seq);
    }

    public static Updates updateShortChatMessage(int id, int from_id, int chat_id, string message, int pts, int date,
        int seq)
    {
        return new UpdateShortChatMessageConstructor(id, from_id, chat_id, message, pts, date, seq);
    }

    public static Updates updateShort(Update update, int date)
    {
        return new UpdateShortConstructor(update, date);
    }

    public static Updates updatesCombined(List<Update> updates, List<User> users, List<Chat> chats, int date,
        int seq_start, int seq)
    {
        return new UpdatesCombinedConstructor(updates, users, chats, date, seq_start, seq);
    }

    public static Updates updates(List<Update> updates, List<User> users, List<Chat> chats, int date, int seq)
    {
        return new UpdatesConstructor(updates, users, chats, date, seq);
    }

    public static photos_Photos photos_photos(List<Photo> photos, List<User> users)
    {
        return new Photos_photosConstructor(photos, users);
    }

    public static photos_Photos photos_photosSlice(int count, List<Photo> photos, List<User> users)
    {
        return new Photos_photosSliceConstructor(count, photos, users);
    }

    public static photos_Photo photos_photo(Photo photo, List<User> users)
    {
        return new Photos_photoConstructor(photo, users);
    }

    public static upload_File upload_file(storage_FileType type, int mtime, byte[] bytes)
    {
        return new Upload_fileConstructor(type, mtime, bytes);
    }

    public static DcOption dcOption(int id, string hostname, string ip_address, int port)
    {
        return new DcOptionConstructor(id, hostname, ip_address, port);
    }

    public static Config config(int date, bool test_mode, int this_dc, List<DcOption> dc_options, int chat_size_max)
    {
        return new ConfigConstructor(date, test_mode, this_dc, dc_options, chat_size_max);
    }

    public static NearestDc nearestDc(string country, int this_dc, int nearest_dc)
    {
        return new NearestDcConstructor(country, this_dc, nearest_dc);
    }

    public static help_AppUpdate help_appUpdate(int id, bool critical, string url, string text)
    {
        return new Help_appUpdateConstructor(id, critical, url, text);
    }

    public static help_AppUpdate help_noAppUpdate()
    {
        return new Help_noAppUpdateConstructor();
    }

    public static help_InviteText help_inviteText(string message)
    {
        return new Help_inviteTextConstructor(message);
    }

    public static messages_StatedMessages messages_statedMessagesLinks(List<Message> messages, List<Chat> chats,
        List<User> users, List<contacts_Link> links, int pts, int seq)
    {
        return new Messages_statedMessagesLinksConstructor(messages, chats, users, links, pts, seq);
    }

    public static messages_StatedMessage messages_statedMessageLink(Message message, List<Chat> chats, List<User> users,
        List<contacts_Link> links, int pts, int seq)
    {
        return new Messages_statedMessageLinkConstructor(message, chats, users, links, pts, seq);
    }

    public static messages_SentMessage messages_sentMessageLink(int id, int date, int pts, int seq,
        List<contacts_Link> links)
    {
        return new Messages_sentMessageLinkConstructor(id, date, pts, seq, links);
    }

    public static InputGeoChat inputGeoChat(int chat_id, long access_hash)
    {
        return new InputGeoChatConstructor(chat_id, access_hash);
    }

    public static InputNotifyPeer inputNotifyGeoChatPeer(InputGeoChat peer)
    {
        return new InputNotifyGeoChatPeerConstructor(peer);
    }

    public static Chat geoChat(int id, long access_hash, string title, string address, string venue, GeoPoint geo,
        ChatPhoto photo, int participants_count, int date, bool checked_in, int version)
    {
        return new GeoChatConstructor(id, access_hash, title, address, venue, geo, photo, participants_count, date,
            checked_in, version);
    }

    public static GeoChatMessage geoChatMessageEmpty(int chat_id, int id)
    {
        return new GeoChatMessageEmptyConstructor(chat_id, id);
    }

    public static GeoChatMessage geoChatMessage(int chat_id, int id, int from_id, int date, string message,
        MessageMedia media)
    {
        return new GeoChatMessageConstructor(chat_id, id, from_id, date, message, media);
    }

    public static GeoChatMessage geoChatMessageService(int chat_id, int id, int from_id, int date, MessageAction action)
    {
        return new GeoChatMessageServiceConstructor(chat_id, id, from_id, date, action);
    }

    public static geochats_StatedMessage geochats_statedMessage(GeoChatMessage message, List<Chat> chats, List<User> users,
        int seq)
    {
        return new Geochats_statedMessageConstructor(message, chats, users, seq);
    }

    public static geochats_Located geochats_located(List<ChatLocated> results, List<GeoChatMessage> messages,
        List<Chat> chats, List<User> users)
    {
        return new Geochats_locatedConstructor(results, messages, chats, users);
    }

    public static geochats_Messages geochats_messages(List<GeoChatMessage> messages, List<Chat> chats, List<User> users)
    {
        return new Geochats_messagesConstructor(messages, chats, users);
    }

    public static geochats_Messages geochats_messagesSlice(int count, List<GeoChatMessage> messages, List<Chat> chats,
        List<User> users)
    {
        return new Geochats_messagesSliceConstructor(count, messages, chats, users);
    }

    public static MessageAction messageActionGeoChatCreate(string title, string address)
    {
        return new MessageActionGeoChatCreateConstructor(title, address);
    }

    public static MessageAction messageActionGeoChatCheckin()
    {
        return new MessageActionGeoChatCheckinConstructor();
    }

    public static Update updateNewGeoChatMessage(GeoChatMessage message)
    {
        return new UpdateNewGeoChatMessageConstructor(message);
    }

    public static WallPaper wallPaperSolid(int id, string title, int bg_color, int color)
    {
        return new WallPaperSolidConstructor(id, title, bg_color, color);
    }

    public static Update updateNewEncryptedMessage(EncryptedMessage message, int qts)
    {
        return new UpdateNewEncryptedMessageConstructor(message, qts);
    }

    public static Update updateEncryptedChatTyping(int chat_id)
    {
        return new UpdateEncryptedChatTypingConstructor(chat_id);
    }

    public static Update updateEncryption(EncryptedChat chat, int date)
    {
        return new UpdateEncryptionConstructor(chat, date);
    }

    public static Update updateEncryptedMessagesRead(int chat_id, int max_date, int date)
    {
        return new UpdateEncryptedMessagesReadConstructor(chat_id, max_date, date);
    }

    public static EncryptedChat encryptedChatEmpty(int id)
    {
        return new EncryptedChatEmptyConstructor(id);
    }

    public static EncryptedChat encryptedChatWaiting(int id, long access_hash, int date, int admin_id, int participant_id)
    {
        return new EncryptedChatWaitingConstructor(id, access_hash, date, admin_id, participant_id);
    }

    public static EncryptedChat encryptedChatRequested(int id, long access_hash, int date, int admin_id,
        int participant_id, byte[] g_a, byte[] nonce)
    {
        return new EncryptedChatRequestedConstructor(id, access_hash, date, admin_id, participant_id, g_a, nonce);
    }

    public static EncryptedChat encryptedChat(int id, long access_hash, int date, int admin_id, int participant_id,
        byte[] g_a_or_b, byte[] nonce, long key_fingerprint)
    {
        return new EncryptedChatConstructor(id, access_hash, date, admin_id, participant_id, g_a_or_b, nonce, key_fingerprint);
    }

    public static EncryptedChat encryptedChatDiscarded(int id)
    {
        return new EncryptedChatDiscardedConstructor(id);
    }

    public static InputEncryptedChat inputEncryptedChat(int chat_id, long access_hash)
    {
        return new InputEncryptedChatConstructor(chat_id, access_hash);
    }

    public static EncryptedFile encryptedFileEmpty()
    {
        return new EncryptedFileEmptyConstructor();
    }

    public static EncryptedFile encryptedFile(long id, long access_hash, int size, int dc_id, int key_fingerprint)
    {
        return new EncryptedFileConstructor(id, access_hash, size, dc_id, key_fingerprint);
    }

    public static InputEncryptedFile inputEncryptedFileEmpty()
    {
        return new InputEncryptedFileEmptyConstructor();
    }

    public static InputEncryptedFile inputEncryptedFileUploaded(long id, int parts, string md5_checksum,
        int key_fingerprint)
    {
        return new InputEncryptedFileUploadedConstructor(id, parts, md5_checksum, key_fingerprint);
    }

    public static InputEncryptedFile inputEncryptedFile(long id, long access_hash)
    {
        return new InputEncryptedFileConstructor(id, access_hash);
    }

    public static InputFileLocation inputEncryptedFileLocation(long id, long access_hash)
    {
        return new InputEncryptedFileLocationConstructor(id, access_hash);
    }

    public static EncryptedMessage encryptedMessage(long random_id, int chat_id, int date, byte[] bytes,
        EncryptedFile file)
    {
        return new EncryptedMessageConstructor(random_id, chat_id, date, bytes, file);
    }

    public static EncryptedMessage encryptedMessageService(long random_id, int chat_id, int date, byte[] bytes)
    {
        return new EncryptedMessageServiceConstructor(random_id, chat_id, date, bytes);
    }

    public static DecryptedMessageLayer decryptedMessageLayer(int layer, DecryptedMessage message)
    {
        return new DecryptedMessageLayerConstructor(layer, message);
    }

    public static DecryptedMessage decryptedMessage(long random_id, byte[] random_bytes, string message,
        DecryptedMessageMedia media)
    {
        return new DecryptedMessageConstructor(random_id, random_bytes, message, media);
    }

    public static DecryptedMessage decryptedMessageService(long random_id, byte[] random_bytes,
        DecryptedMessageAction action)
    {
        return new DecryptedMessageServiceConstructor(random_id, random_bytes, action);
    }

    public static DecryptedMessageMedia decryptedMessageMediaEmpty()
    {
        return new DecryptedMessageMediaEmptyConstructor();
    }

    public static DecryptedMessageMedia decryptedMessageMediaPhoto(byte[] thumb, int thumb_w, int thumb_h, int w, int h,
        int size, byte[] key, byte[] iv)
    {
        return new DecryptedMessageMediaPhotoConstructor(thumb, thumb_w, thumb_h, w, h, size, key, iv);
    }

    public static DecryptedMessageMedia decryptedMessageMediaVideo(byte[] thumb, int thumb_w, int thumb_h, int duration,
        int w, int h, int size, byte[] key, byte[] iv)
    {
        return new DecryptedMessageMediaVideoConstructor(thumb, thumb_w, thumb_h, duration, w, h, size, key, iv);
    }

    public static DecryptedMessageMedia decryptedMessageMediaGeoPoint(double lat, double lng)
    {
        return new DecryptedMessageMediaGeoPointConstructor(lat, lng);
    }

    public static DecryptedMessageMedia decryptedMessageMediaContact(string phone_number, string first_name,
        string last_name, int user_id)
    {
        return new DecryptedMessageMediaContactConstructor(phone_number, first_name, last_name, user_id);
    }

    public static DecryptedMessageAction decryptedMessageActionSetMessageTTL(int ttl_seconds)
    {
        return new DecryptedMessageActionSetMessageTTLConstructor(ttl_seconds);
    }

    public static messages_DhConfig messages_dhConfigNotModified(byte[] random)
    {
        return new Messages_dhConfigNotModifiedConstructor(random);
    }

    public static messages_DhConfig messages_dhConfig(int g, byte[] p, int version, byte[] random)
    {
        return new Messages_dhConfigConstructor(g, p, version, random);
    }

    public static messages_SentEncryptedMessage messages_sentEncryptedMessage(int date)
    {
        return new Messages_sentEncryptedMessageConstructor(date);
    }

    public static messages_SentEncryptedMessage messages_sentEncryptedFile(int date, EncryptedFile file)
    {
        return new Messages_sentEncryptedFileConstructor(date, file);
    }

    public static InputFile inputFileBig(long id, int parts, string name)
    {
        return new InputFileBigConstructor(id, parts, name);
    }

    public static InputEncryptedFile inputEncryptedFileBigUploaded(long id, int parts, int key_fingerprint)
    {
        return new InputEncryptedFileBigUploadedConstructor(id, parts, key_fingerprint);
    }

    public static Update updateChatParticipantAdd(int chat_id, int user_id, int inviter_id, int version)
    {
        return new UpdateChatParticipantAddConstructor(chat_id, user_id, inviter_id, version);
    }

    public static Update updateChatParticipantDelete(int chat_id, int user_id, int version)
    {
        return new UpdateChatParticipantDeleteConstructor(chat_id, user_id, version);
    }

    public static Update updateDcOptions(List<DcOption> dc_options)
    {
        return new UpdateDcOptionsConstructor(dc_options);
    }

    public static InputMedia inputMediaUploadedAudio(InputFile file, int duration)
    {
        return new InputMediaUploadedAudioConstructor(file, duration);
    }

    public static InputMedia inputMediaAudio(InputAudio id)
    {
        return new InputMediaAudioConstructor(id);
    }

    public static InputMedia inputMediaUploadedDocument(InputFile file, string file_name, string mime_type)
    {
        return new InputMediaUploadedDocumentConstructor(file, file_name, mime_type);
    }

    public static InputMedia inputMediaUploadedThumbDocument(InputFile file, InputFile thumb, string file_name,
        string mime_type)
    {
        return new InputMediaUploadedThumbDocumentConstructor(file, thumb, file_name, mime_type);
    }

    public static InputMedia inputMediaDocument(InputDocument id)
    {
        return new InputMediaDocumentConstructor(id);
    }

    public static MessageMedia messageMediaDocument(Document document)
    {
        return new MessageMediaDocumentConstructor(document);
    }

    public static MessageMedia messageMediaAudio(Audio audio)
    {
        return new MessageMediaAudioConstructor(audio);
    }

    public static InputAudio inputAudioEmpty()
    {
        return new InputAudioEmptyConstructor();
    }

    public static InputAudio inputAudio(long id, long access_hash)
    {
        return new InputAudioConstructor(id, access_hash);
    }

    public static InputDocument inputDocumentEmpty()
    {
        return new InputDocumentEmptyConstructor();
    }

    public static InputDocument inputDocument(long id, long access_hash)
    {
        return new InputDocumentConstructor(id, access_hash);
    }

    public static InputFileLocation inputAudioFileLocation(long id, long access_hash)
    {
        return new InputAudioFileLocationConstructor(id, access_hash);
    }

    public static InputFileLocation inputDocumentFileLocation(long id, long access_hash)
    {
        return new InputDocumentFileLocationConstructor(id, access_hash);
    }

    public static DecryptedMessageMedia decryptedMessageMediaDocument(byte[] thumb, int thumb_w, int thumb_h,
        string file_name, string mime_type, int size, byte[] key, byte[] iv)
    {
        return new DecryptedMessageMediaDocumentConstructor(thumb, thumb_w, thumb_h, file_name, mime_type, size, key, iv);
    }

    public static DecryptedMessageMedia decryptedMessageMediaAudio(int duration, int size, byte[] key, byte[] iv)
    {
        return new DecryptedMessageMediaAudioConstructor(duration, size, key, iv);
    }

    public static Audio audioEmpty(long id)
    {
        return new AudioEmptyConstructor(id);
    }

    public static Document documentEmpty(long id)
    {
        return new DocumentEmptyConstructor(id);
    }

    public static Document document(long id, long access_hash, int user_id, int date, string file_name, string mime_type,
        int size, PhotoSize thumb, int dc_id)
    {
        return new DocumentConstructor(id, access_hash, user_id, date, file_name, mime_type, size, thumb, dc_id);
    }

    public static Type GetCombinatorType(uint dataCode)
    {
        Type value;

        return constructors.TryGetValue(dataCode, out value) ? value : GetCombinatorTypeReflection(dataCode);
    }

    static Type GetCombinatorTypeReflection(uint dataCode)
    {
        if (_cachedTypes == null)
            CreateTypesCache();

        // ReSharper disable once AssignNullToNotNullAttribute
        var single = _cachedTypes.SingleOrDefault(type => ((Combinator)type.GetProperty("Combinator").GetValue(null)).Name == dataCode);

        return single;
    }

    static void CreateTypesCache()
    {
        var types = Assembly.GetExecutingAssembly().GetTypes();

        var enumerable = types.Where(type => typeof(TLObject).IsAssignableFrom(type));

        _cachedTypes = enumerable.Where(type => type.GetProperties().Any(info => info.Name == "Combinator")).ToArray();
    }
}
using System;
using System.Collections.Generic;
using System.IO;

namespace TLSharp.Core.MTProto
{

	public abstract class TLObject
	{
		public abstract void Write(BinaryWriter writer);
		public abstract void Read(BinaryReader reader);
	}

	// all constructor types

	public enum Constructor
	{
		messageUndelivered,
		error,
		inputPeerEmpty,
		inputPeerSelf,
		inputPeerContact,
		inputPeerForeign,
		inputPeerChat,
		inputUserEmpty,
		inputUserSelf,
		inputUserContact,
		inputUserForeign,
		inputPhoneContact,
		inputFile,
		inputMediaEmpty,
		inputMediaUploadedPhoto,
		inputMediaPhoto,
		inputMediaGeoPoint,
		inputMediaContact,
		inputMediaUploadedVideo,
		inputMediaUploadedThumbVideo,
		inputMediaVideo,
		inputChatPhotoEmpty,
		inputChatUploadedPhoto,
		inputChatPhoto,
		inputGeoPointEmpty,
		inputGeoPoint,
		inputPhotoEmpty,
		inputPhoto,
		inputVideoEmpty,
		inputVideo,
		inputFileLocation,
		inputVideoFileLocation,
		inputPhotoCropAuto,
		inputPhotoCrop,
		inputAppEvent,
		peerUser,
		peerChat,
		storage_fileUnknown,
		storage_fileJpeg,
		storage_fileGif,
		storage_filePng,
		storage_fileMp3,
		storage_fileMov,
		storage_filePartial,
		storage_fileMp4,
		storage_fileWebp,
		fileLocationUnavailable,
		fileLocation,
		userEmpty,
		userSelf,
		userContact,
		userRequest,
		userForeign,
		userDeleted,
		userProfilePhotoEmpty,
		userProfilePhoto,
		userStatusEmpty,
		userStatusOnline,
		userStatusOffline,
		chatEmpty,
		chat,
		chatForbidden,
		chatFull,
		chatParticipant,
		chatParticipantsForbidden,
		chatParticipants,
		chatPhotoEmpty,
		chatPhoto,
		messageEmpty,
		message,
		messageForwarded,
		messageService,
		messageMediaEmpty,
		messageMediaPhoto,
		messageMediaVideo,
		messageMediaGeo,
		messageMediaContact,
		messageMediaUnsupported,
		messageActionEmpty,
		messageActionChatCreate,
		messageActionChatEditTitle,
		messageActionChatEditPhoto,
		messageActionChatDeletePhoto,
		messageActionChatAddUser,
		messageActionChatDeleteUser,
		dialog,
		photoEmpty,
		photo,
		photoSizeEmpty,
		photoSize,
		photoCachedSize,
		videoEmpty,
		video,
		geoPointEmpty,
		geoPoint,
		auth_checkedPhone,
		auth_sentCode,
		auth_authorization,
		auth_exportedAuthorization,
		inputNotifyPeer,
		inputNotifyUsers,
		inputNotifyChats,
		inputNotifyAll,
		inputPeerNotifyEventsEmpty,
		inputPeerNotifyEventsAll,
		inputPeerNotifySettings,
		peerNotifyEventsEmpty,
		peerNotifyEventsAll,
		peerNotifySettingsEmpty,
		peerNotifySettings,
		wallPaper,
		userFull,
		contact,
		importedContact,
		contactBlocked,
		contactFound,
		contactSuggested,
		contactStatus,
		chatLocated,
		contacts_foreignLinkUnknown,
		contacts_foreignLinkRequested,
		contacts_foreignLinkMutual,
		contacts_myLinkEmpty,
		contacts_myLinkRequested,
		contacts_myLinkContact,
		contacts_link,
		contacts_contacts,
		contacts_contactsNotModified,
		contacts_importedContacts,
		contacts_blocked,
		contacts_blockedSlice,
		contacts_found,
		contacts_suggested,
		messages_dialogs,
		messages_dialogsSlice,
		messages_messages,
		messages_messagesSlice,
		messages_messageEmpty,
		messages_message,
		messages_statedMessages,
		messages_statedMessage,
		messages_sentMessage,
		messages_chat,
		messages_chats,
		messages_chatFull,
		messages_affectedHistory,
		inputMessagesFilterEmpty,
		inputMessagesFilterPhotos,
		inputMessagesFilterVideo,
		inputMessagesFilterPhotoVideo,
		updateNewMessage,
		updateMessageID,
		updateReadMessages,
		updateDeleteMessages,
		updateRestoreMessages,
		updateUserTyping,
		updateChatUserTyping,
		updateChatParticipants,
		updateUserStatus,
		updateUserName,
		updateUserPhoto,
		updateContactRegistered,
		updateContactLink,
		updateActivation,
		updateNewAuthorization,
		updates_state,
		updates_differenceEmpty,
		updates_difference,
		updates_differenceSlice,
		updatesTooLong,
		updateShortMessage,
		updateShortChatMessage,
		updateShort,
		updatesCombined,
		updates,
		photos_photos,
		photos_photosSlice,
		photos_photo,
		upload_file,
		dcOption,
		config,
		nearestDc,
		help_appUpdate,
		help_noAppUpdate,
		help_inviteText,
		messages_statedMessagesLinks,
		messages_statedMessageLink,
		messages_sentMessageLink,
		inputGeoChat,
		inputNotifyGeoChatPeer,
		geoChat,
		geoChatMessageEmpty,
		geoChatMessage,
		geoChatMessageService,
		geochats_statedMessage,
		geochats_located,
		geochats_messages,
		geochats_messagesSlice,
		messageActionGeoChatCreate,
		messageActionGeoChatCheckin,
		updateNewGeoChatMessage,
		wallPaperSolid,
		updateNewEncryptedMessage,
		updateEncryptedChatTyping,
		updateEncryption,
		updateEncryptedMessagesRead,
		encryptedChatEmpty,
		encryptedChatWaiting,
		encryptedChatRequested,
		encryptedChat,
		encryptedChatDiscarded,
		inputEncryptedChat,
		encryptedFileEmpty,
		encryptedFile,
		inputEncryptedFileEmpty,
		inputEncryptedFileUploaded,
		inputEncryptedFile,
		inputEncryptedFileLocation,
		encryptedMessage,
		encryptedMessageService,
		decryptedMessageLayer,
		decryptedMessage,
		decryptedMessageService,
		decryptedMessageMediaEmpty,
		decryptedMessageMediaPhoto,
		decryptedMessageMediaVideo,
		decryptedMessageMediaGeoPoint,
		decryptedMessageMediaContact,
		decryptedMessageActionSetMessageTTL,
		messages_dhConfigNotModified,
		messages_dhConfig,
		messages_sentEncryptedMessage,
		messages_sentEncryptedFile,
		inputFileBig,
		inputEncryptedFileBigUploaded,
		updateChatParticipantAdd,
		updateChatParticipantDelete,
		updateDcOptions,
		inputMediaUploadedAudio,
		inputMediaAudio,
		inputMediaUploadedDocument,
		inputMediaUploadedThumbDocument,
		inputMediaDocument,
		messageMediaDocument,
		messageMediaAudio,
		inputAudioEmpty,
		inputAudio,
		inputDocumentEmpty,
		inputDocument,
		inputAudioFileLocation,
		inputDocumentFileLocation,
		decryptedMessageMediaDocument,
		decryptedMessageMediaAudio,
		audioEmpty,
		audio,
		documentEmpty,
		document
	}

    // abstract types
	public abstract class contacts_ImportedContacts : TLObject
	{

	}

	public abstract class Peer : TLObject
	{

	}

	public abstract class InputVideo : TLObject
	{

	}

	public abstract class help_InviteText : TLObject
	{

	}

	public abstract class UserStatus : TLObject
	{

	}

	public abstract class MessagesFilter : TLObject
	{

	}

	public abstract class Error : TLObject
	{

	}

	public abstract class Updates : TLObject
	{

	}

	public abstract class help_AppUpdate : TLObject
	{

	}

	public abstract class InputEncryptedChat : TLObject
	{

	}

	public abstract class DecryptedMessage : TLObject
	{

	}

	public abstract class InputAudio : TLObject
	{

	}

	public abstract class ChatLocated : TLObject
	{

	}

	public abstract class PhotoSize : TLObject
	{

	}

	public abstract class messages_SentEncryptedMessage : TLObject
	{

	}

	public abstract class MessageMedia : TLObject
	{

	}

	public abstract class InputDocument : TLObject
	{

	}

	public abstract class ImportedContact : TLObject
	{

	}

	public abstract class ContactBlocked : TLObject
	{

	}

	public abstract class Message : TLObject
	{

	}

	public abstract class InputNotifyPeer : TLObject
	{

	}

	public abstract class messages_ChatFull : TLObject
	{

	}

	public abstract class ChatParticipant : TLObject
	{

	}

	public abstract class InputPhoto : TLObject
	{

	}

	public abstract class DecryptedMessageMedia : TLObject
	{

	}

	public abstract class InputFileLocation : TLObject
	{

	}

	public abstract class InputEncryptedFile : TLObject
	{

	}

	public abstract class contacts_ForeignLink : TLObject
	{

	}

	public abstract class Document : TLObject
	{

	}

	public abstract class UserFull : TLObject
	{

	}

	public abstract class messages_Message : TLObject
	{

	}

	public abstract class DcOption : TLObject
	{

	}

	public abstract class photos_Photos : TLObject
	{

	}

	public abstract class InputPeerNotifySettings : TLObject
	{

	}

	public abstract class contacts_Suggested : TLObject
	{

	}

	public abstract class InputGeoPoint : TLObject
	{

	}

	public abstract class InputGeoChat : TLObject
	{

	}

	public abstract class InputContact : TLObject
	{

	}

	public abstract class EncryptedFile : TLObject
	{

	}

	public abstract class PeerNotifySettings : TLObject
	{

	}

	public abstract class auth_Authorization : TLObject
	{

	}

	public abstract class auth_CheckedPhone : TLObject
	{

	}

	public abstract class FileLocation : TLObject
	{

	}

	public abstract class messages_Chats : TLObject
	{

	}

	public abstract class contacts_Link : TLObject
	{

	}

	public abstract class messages_StatedMessage : TLObject
	{

	}

	public abstract class geochats_Located : TLObject
	{

	}

	public abstract class updates_State : TLObject
	{

	}

	public abstract class storage_FileType : TLObject
	{

	}

	public abstract class geochats_StatedMessage : TLObject
	{

	}

	public abstract class ContactFound : TLObject
	{

	}

	public abstract class Photo : TLObject
	{

	}

	public abstract class InputMedia : TLObject
	{

	}

	public abstract class photos_Photo : TLObject
	{

	}

	public abstract class InputFile : TLObject
	{

	}

	public abstract class auth_ExportedAuthorization : TLObject
	{

	}

	public abstract class User : TLObject
	{

	}

	public abstract class NearestDc : TLObject
	{

	}

	public abstract class Video : TLObject
	{

	}

	public abstract class contacts_Blocked : TLObject
	{

	}

	public abstract class messages_AffectedHistory : TLObject
	{

	}

	public abstract class messages_Chat : TLObject
	{

	}

	public abstract class Chat : TLObject
	{

	}

	public abstract class ChatParticipants : TLObject
	{

	}

	public abstract class InputAppEvent : TLObject
	{

	}

	public abstract class messages_Messages : TLObject
	{

	}

	public abstract class messages_Dialogs : TLObject
	{

	}

	public abstract class InputPeer : TLObject
	{

	}

	public abstract class ChatPhoto : TLObject
	{

	}

	public abstract class contacts_MyLink : TLObject
	{

	}

	public abstract class InputChatPhoto : TLObject
	{

	}

	public abstract class messages_SentMessage : TLObject
	{

	}

	public abstract class messages_StatedMessages : TLObject
	{

	}

	public abstract class UserProfilePhoto : TLObject
	{

	}

	public abstract class updates_Difference : TLObject
	{

	}

	public abstract class Update : TLObject
	{

	}

	public abstract class GeoPoint : TLObject
	{

	}

	public abstract class WallPaper : TLObject
	{

	}

	public abstract class DecryptedMessageLayer : TLObject
	{

	}

	public abstract class Config : TLObject
	{

	}

	public abstract class EncryptedMessage : TLObject
	{

	}

	public abstract class Dialog : TLObject
	{

	}

	public abstract class ContactStatus : TLObject
	{

	}

	public abstract class InputPeerNotifyEvents : TLObject
	{

	}

	public abstract class MessageAction : TLObject
	{

	}

	public abstract class DecryptedMessageAction : TLObject
	{

	}

	public abstract class auth_SentCode : TLObject
	{

	}

	public abstract class geochats_Messages : TLObject
	{

	}

	public abstract class InputUser : TLObject
	{

	}

	public abstract class EncryptedChat : TLObject
	{

	}

	public abstract class contacts_Contacts : TLObject
	{

	}

	public abstract class GeoChatMessage : TLObject
	{

	}

	public abstract class PeerNotifyEvents : TLObject
	{

	}

	public abstract class contacts_Found : TLObject
	{

	}

	public abstract class Audio : TLObject
	{

	}

	public abstract class ChatFull : TLObject
	{

	}

	public abstract class messages_DhConfig : TLObject
	{

	}

	public abstract class Contact : TLObject
	{

	}

	public abstract class upload_File : TLObject
	{

	}

	public abstract class InputPhotoCrop : TLObject
	{

	}

	public abstract class ContactSuggested : TLObject
	{

	}

	// types implementations


	public class ErrorConstructor : Error
	{
		public int code;
		public string text;

		public ErrorConstructor()
		{

		}

		public ErrorConstructor(int code, string text)
		{
			this.code = code;
			this.text = text;
		}


		public Constructor Constructor
		{
			get { return Constructor.error; }
		}

		public override void Write(BinaryWriter writer)
		{
			writer.Write(0xc4b9f9bb);
			writer.Write(this.code);
			Serializers.String.write(writer, this.text);
		}

		public override void Read(BinaryReader reader)
		{
			this.code = reader.ReadInt32();
			this.text = Serializers.String.read(reader);
		}

		public override string ToString()
		{
			return String.Format("(error code:{0} text:'{1}')", code, text);
		}
	}


	public class InputPeerEmptyConstructor : InputPeer
	{

		public InputPeerEmptyConstructor()
		{

		}



		public Constructor Constructor
		{
			get { return Constructor.inputPeerEmpty; }
		}

		public override void Write(BinaryWriter writer)
		{
			writer.Write(0x7f3b18ea);
		}

		public override void Read(BinaryReader reader)
		{
		}

		public override string ToString()
		{
			return String.Format("(inputPeerEmpty)");
		}
	}


	public class InputPeerSelfConstructor : InputPeer
	{

		public InputPeerSelfConstructor()
		{

		}



		public Constructor Constructor
		{
			get { return Constructor.inputPeerSelf; }
		}

		public override void Write(BinaryWriter writer)
		{
			writer.Write(0x7da07ec9);
		}

		public override void Read(BinaryReader reader)
		{
		}

		public override string ToString()
		{
			return String.Format("(inputPeerSelf)");
		}
	}


	public class InputPeerContactConstructor : InputPeer
	{
		public int user_id;

		public InputPeerContactConstructor()
		{

		}

		public InputPeerContactConstructor(int user_id)
		{
			this.user_id = user_id;
		}


		public Constructor Constructor
		{
			get { return Constructor.inputPeerContact; }
		}

		public override void Write(BinaryWriter writer)
		{
			writer.Write(0x1023dbe8);
			writer.Write(this.user_id);
		}

		public override void Read(BinaryReader reader)
		{
			this.user_id = reader.ReadInt32();
		}

		public override string ToString()
		{
			return String.Format("(inputPeerContact user_id:{0})", user_id);
		}
	}


	public class InputPeerForeignConstructor : InputPeer
	{
		public int user_id;
		public long access_hash;

		public InputPeerForeignConstructor()
		{

		}

		public InputPeerForeignConstructor(int user_id, long access_hash)
		{
			this.user_id = user_id;
			this.access_hash = access_hash;
		}


		public Constructor Constructor
		{
			get { return Constructor.inputPeerForeign; }
		}

		public override void Write(BinaryWriter writer)
		{
			writer.Write(0x9b447325);
			writer.Write(this.user_id);
			writer.Write(this.access_hash);
		}

		public override void Read(BinaryReader reader)
		{
			this.user_id = reader.ReadInt32();
			this.access_hash = reader.ReadInt64();
		}

		public override string ToString()
		{
			return String.Format("(inputPeerForeign user_id:{0} access_hash:{1})", user_id, access_hash);
		}
	}


	public class InputPeerChatConstructor : InputPeer
	{
		public int chat_id;

		public InputPeerChatConstructor()
		{

		}

		public InputPeerChatConstructor(int chat_id)
		{
			this.chat_id = chat_id;
		}


		public Constructor Constructor
		{
			get { return Constructor.inputPeerChat; }
		}

		public override void Write(BinaryWriter writer)
		{
			writer.Write(0x179be863);
			writer.Write(this.chat_id);
		}

		public override void Read(BinaryReader reader)
		{
			this.chat_id = reader.ReadInt32();
		}

		public override string ToString()
		{
			return String.Format("(inputPeerChat chat_id:{0})", chat_id);
		}
	}


	public class InputUserEmptyConstructor : InputUser
	{

		public InputUserEmptyConstructor()
		{

		}



		public Constructor Constructor
		{
			get { return Constructor.inputUserEmpty; }
		}

		public override void Write(BinaryWriter writer)
		{
			writer.Write(0xb98886cf);
		}

		public override void Read(BinaryReader reader)
		{
		}

		public override string ToString()
		{
			return String.Format("(inputUserEmpty)");
		}
	}


	public class InputUserSelfConstructor : InputUser
	{

		public InputUserSelfConstructor()
		{

		}



		public Constructor Constructor
		{
			get { return Constructor.inputUserSelf; }
		}

		public override void Write(BinaryWriter writer)
		{
			writer.Write(0xf7c1b13f);
		}

		public override void Read(BinaryReader reader)
		{
		}

		public override string ToString()
		{
			return String.Format("(inputUserSelf)");
		}
	}


	public class InputUserContactConstructor : InputUser
	{
		public int user_id;

		public InputUserContactConstructor()
		{

		}

		public InputUserContactConstructor(int user_id)
		{
			this.user_id = user_id;
		}


		public Constructor Constructor
		{
			get { return Constructor.inputUserContact; }
		}

		public override void Write(BinaryWriter writer)
		{
			writer.Write(0x86e94f65);
			writer.Write(this.user_id);
		}

		public override void Read(BinaryReader reader)
		{
			this.user_id = reader.ReadInt32();
		}

		public override string ToString()
		{
			return String.Format("(inputUserContact user_id:{0})", user_id);
		}
	}


	public class InputUserForeignConstructor : InputUser
	{
		public int user_id;
		public long access_hash;

		public InputUserForeignConstructor()
		{

		}

		public InputUserForeignConstructor(int user_id, long access_hash)
		{
			this.user_id = user_id;
			this.access_hash = access_hash;
		}


		public Constructor Constructor
		{
			get { return Constructor.inputUserForeign; }
		}

		public override void Write(BinaryWriter writer)
		{
			writer.Write(0x655e74ff);
			writer.Write(this.user_id);
			writer.Write(this.access_hash);
		}

		public override void Read(BinaryReader reader)
		{
			this.user_id = reader.ReadInt32();
			this.access_hash = reader.ReadInt64();
		}

		public override string ToString()
		{
			return String.Format("(inputUserForeign user_id:{0} access_hash:{1})", user_id, access_hash);
		}
	}


	public class InputPhoneContactConstructor : InputContact
	{
		public long client_id;
		public string phone;
		public string first_name;
		public string last_name;

		public InputPhoneContactConstructor()
		{

		}

		public InputPhoneContactConstructor(long client_id, string phone, string first_name, string last_name)
		{
			this.client_id = client_id;
			this.phone = phone;
			this.first_name = first_name;
			this.last_name = last_name;
		}


		public Constructor Constructor
		{
			get { return Constructor.inputPhoneContact; }
		}

		public override void Write(BinaryWriter writer)
		{
			writer.Write(0xf392b7f4);
			writer.Write(this.client_id);
			Serializers.String.write(writer, this.phone);
			Serializers.String.write(writer, this.first_name);
			Serializers.String.write(writer, this.last_name);
		}

		public override void Read(BinaryReader reader)
		{
			this.client_id = reader.ReadInt64();
			this.phone = Serializers.String.read(reader);
			this.first_name = Serializers.String.read(reader);
			this.last_name = Serializers.String.read(reader);
		}

		public override string ToString()
		{
			return String.Format("(inputPhoneContact client_id:{0} phone:'{1}' first_name:'{2}' last_name:'{3}')", client_id,
				phone, first_name, last_name);
		}
	}


	public class InputFileConstructor : InputFile
	{
		public long id;
		public int parts;
		public string name;
		public string md5_checksum;

		public InputFileConstructor()
		{

		}

		public InputFileConstructor(long id, int parts, string name, string md5_checksum)
		{
			this.id = id;
			this.parts = parts;
			this.name = name;
			this.md5_checksum = md5_checksum;
		}


		public Constructor Constructor
		{
			get { return Constructor.inputFile; }
		}

		public override void Write(BinaryWriter writer)
		{
			writer.Write(0xf52ff27f);
			writer.Write(this.id);
			writer.Write(this.parts);
			Serializers.String.write(writer, this.name);
			Serializers.String.write(writer, this.md5_checksum);
		}

		public override void Read(BinaryReader reader)
		{
			this.id = reader.ReadInt64();
			this.parts = reader.ReadInt32();
			this.name = Serializers.String.read(reader);
			this.md5_checksum = Serializers.String.read(reader);
		}

		public override string ToString()
		{
			return String.Format("(inputFile id:{0} parts:{1} name:'{2}' md5_checksum:'{3}')", id, parts, name, md5_checksum);
		}
	}


	public class InputMediaEmptyConstructor : InputMedia
	{

		public InputMediaEmptyConstructor()
		{

		}



		public Constructor Constructor
		{
			get { return Constructor.inputMediaEmpty; }
		}

		public override void Write(BinaryWriter writer)
		{
			writer.Write(0x9664f57f);
		}

		public override void Read(BinaryReader reader)
		{
		}

		public override string ToString()
		{
			return String.Format("(inputMediaEmpty)");
		}
	}


	public class InputMediaUploadedPhotoConstructor : InputMedia
	{
		public InputFile file;

		public InputMediaUploadedPhotoConstructor()
		{

		}

		public InputMediaUploadedPhotoConstructor(InputFile file)
		{
			this.file = file;
		}


		public Constructor Constructor
		{
			get { return Constructor.inputMediaUploadedPhoto; }
		}

		public override void Write(BinaryWriter writer)
		{
			writer.Write(0x2dc53a7d);
			this.file.Write(writer);
		}

		public override void Read(BinaryReader reader)
		{
			this.file = TL.Parse<InputFile>(reader);
		}

		public override string ToString()
		{
			return String.Format("(inputMediaUploadedPhoto file:{0})", file);
		}
	}


	public class InputMediaPhotoConstructor : InputMedia
	{
		public InputPhoto id;

		public InputMediaPhotoConstructor()
		{

		}

		public InputMediaPhotoConstructor(InputPhoto id)
		{
			this.id = id;
		}


		public Constructor Constructor
		{
			get { return Constructor.inputMediaPhoto; }
		}

		public override void Write(BinaryWriter writer)
		{
			writer.Write(0x8f2ab2ec);
			this.id.Write(writer);
		}

		public override void Read(BinaryReader reader)
		{
			this.id = TL.Parse<InputPhoto>(reader);
		}

		public override string ToString()
		{
			return String.Format("(inputMediaPhoto id:{0})", id);
		}
	}


	public class InputMediaGeoPointConstructor : InputMedia
	{
		public InputGeoPoint geo_point;

		public InputMediaGeoPointConstructor()
		{

		}

		public InputMediaGeoPointConstructor(InputGeoPoint geo_point)
		{
			this.geo_point = geo_point;
		}


		public Constructor Constructor
		{
			get { return Constructor.inputMediaGeoPoint; }
		}

		public override void Write(BinaryWriter writer)
		{
			writer.Write(0xf9c44144);
			this.geo_point.Write(writer);
		}

		public override void Read(BinaryReader reader)
		{
			this.geo_point = TL.Parse<InputGeoPoint>(reader);
		}

		public override string ToString()
		{
			return String.Format("(inputMediaGeoPoint geo_point:{0})", geo_point);
		}
	}


	public class InputMediaContactConstructor : InputMedia
	{
		public string phone_number;
		public string first_name;
		public string last_name;

		public InputMediaContactConstructor()
		{

		}

		public InputMediaContactConstructor(string phone_number, string first_name, string last_name)
		{
			this.phone_number = phone_number;
			this.first_name = first_name;
			this.last_name = last_name;
		}


		public Constructor Constructor
		{
			get { return Constructor.inputMediaContact; }
		}

		public override void Write(BinaryWriter writer)
		{
			writer.Write(0xa6e45987);
			Serializers.String.write(writer, this.phone_number);
			Serializers.String.write(writer, this.first_name);
			Serializers.String.write(writer, this.last_name);
		}

		public override void Read(BinaryReader reader)
		{
			this.phone_number = Serializers.String.read(reader);
			this.first_name = Serializers.String.read(reader);
			this.last_name = Serializers.String.read(reader);
		}

		public override string ToString()
		{
			return String.Format("(inputMediaContact phone_number:'{0}' first_name:'{1}' last_name:'{2}')", phone_number,
				first_name, last_name);
		}
	}


	public class InputMediaUploadedVideoConstructor : InputMedia
	{
		public InputFile file;
		public int duration;
		public int w;
		public int h;

		public InputMediaUploadedVideoConstructor()
		{

		}

		public InputMediaUploadedVideoConstructor(InputFile file, int duration, int w, int h)
		{
			this.file = file;
			this.duration = duration;
			this.w = w;
			this.h = h;
		}


		public Constructor Constructor
		{
			get { return Constructor.inputMediaUploadedVideo; }
		}

		public override void Write(BinaryWriter writer)
		{
			writer.Write(0x4847d92a);
			this.file.Write(writer);
			writer.Write(this.duration);
			writer.Write(this.w);
			writer.Write(this.h);
		}

		public override void Read(BinaryReader reader)
		{
			this.file = TL.Parse<InputFile>(reader);
			this.duration = reader.ReadInt32();
			this.w = reader.ReadInt32();
			this.h = reader.ReadInt32();
		}

		public override string ToString()
		{
			return String.Format("(inputMediaUploadedVideo file:{0} duration:{1} w:{2} h:{3})", file, duration, w, h);
		}
	}


	public class InputMediaUploadedThumbVideoConstructor : InputMedia
	{
		public InputFile file;
		public InputFile thumb;
		public int duration;
		public int w;
		public int h;

		public InputMediaUploadedThumbVideoConstructor()
		{

		}

		public InputMediaUploadedThumbVideoConstructor(InputFile file, InputFile thumb, int duration, int w, int h)
		{
			this.file = file;
			this.thumb = thumb;
			this.duration = duration;
			this.w = w;
			this.h = h;
		}


		public Constructor Constructor
		{
			get { return Constructor.inputMediaUploadedThumbVideo; }
		}

		public override void Write(BinaryWriter writer)
		{
			writer.Write(0xe628a145);
			this.file.Write(writer);
			this.thumb.Write(writer);
			writer.Write(this.duration);
			writer.Write(this.w);
			writer.Write(this.h);
		}

		public override void Read(BinaryReader reader)
		{
			this.file = TL.Parse<InputFile>(reader);
			this.thumb = TL.Parse<InputFile>(reader);
			this.duration = reader.ReadInt32();
			this.w = reader.ReadInt32();
			this.h = reader.ReadInt32();
		}

		public override string ToString()
		{
			return String.Format("(inputMediaUploadedThumbVideo file:{0} thumb:{1} duration:{2} w:{3} h:{4})", file, thumb,
				duration, w, h);
		}
	}


	public class InputMediaVideoConstructor : InputMedia
	{
		public InputVideo id;

		public InputMediaVideoConstructor()
		{

		}

		public InputMediaVideoConstructor(InputVideo id)
		{
			this.id = id;
		}


		public Constructor Constructor
		{
			get { return Constructor.inputMediaVideo; }
		}

		public override void Write(BinaryWriter writer)
		{
			writer.Write(0x7f023ae6);
			this.id.Write(writer);
		}

		public override void Read(BinaryReader reader)
		{
			this.id = TL.Parse<InputVideo>(reader);
		}

		public override string ToString()
		{
			return String.Format("(inputMediaVideo id:{0})", id);
		}
	}


	public class InputChatPhotoEmptyConstructor : InputChatPhoto
	{

		public InputChatPhotoEmptyConstructor()
		{

		}



		public Constructor Constructor
		{
			get { return Constructor.inputChatPhotoEmpty; }
		}

		public override void Write(BinaryWriter writer)
		{
			writer.Write(0x1ca48f57);
		}

		public override void Read(BinaryReader reader)
		{
		}

		public override string ToString()
		{
			return String.Format("(inputChatPhotoEmpty)");
		}
	}


	public class InputChatUploadedPhotoConstructor : InputChatPhoto
	{
		public InputFile file;
		public InputPhotoCrop crop;

		public InputChatUploadedPhotoConstructor()
		{

		}

		public InputChatUploadedPhotoConstructor(InputFile file, InputPhotoCrop crop)
		{
			this.file = file;
			this.crop = crop;
		}


		public Constructor Constructor
		{
			get { return Constructor.inputChatUploadedPhoto; }
		}

		public override void Write(BinaryWriter writer)
		{
			writer.Write(0x94254732);
			this.file.Write(writer);
			this.crop.Write(writer);
		}

		public override void Read(BinaryReader reader)
		{
			this.file = TL.Parse<InputFile>(reader);
			this.crop = TL.Parse<InputPhotoCrop>(reader);
		}

		public override string ToString()
		{
			return String.Format("(inputChatUploadedPhoto file:{0} crop:{1})", file, crop);
		}
	}


	public class InputChatPhotoConstructor : InputChatPhoto
	{
		public InputPhoto id;
		public InputPhotoCrop crop;

		public InputChatPhotoConstructor()
		{

		}

		public InputChatPhotoConstructor(InputPhoto id, InputPhotoCrop crop)
		{
			this.id = id;
			this.crop = crop;
		}


		public Constructor Constructor
		{
			get { return Constructor.inputChatPhoto; }
		}

		public override void Write(BinaryWriter writer)
		{
			writer.Write(0xb2e1bf08);
			this.id.Write(writer);
			this.crop.Write(writer);
		}

		public override void Read(BinaryReader reader)
		{
			this.id = TL.Parse<InputPhoto>(reader);
			this.crop = TL.Parse<InputPhotoCrop>(reader);
		}

		public override string ToString()
		{
			return String.Format("(inputChatPhoto id:{0} crop:{1})", id, crop);
		}
	}


	public class InputGeoPointEmptyConstructor : InputGeoPoint
	{

		public InputGeoPointEmptyConstructor()
		{

		}



		public Constructor Constructor
		{
			get { return Constructor.inputGeoPointEmpty; }
		}

		public override void Write(BinaryWriter writer)
		{
			writer.Write(0xe4c123d6);
		}

		public override void Read(BinaryReader reader)
		{
		}

		public override string ToString()
		{
			return String.Format("(inputGeoPointEmpty)");
		}
	}


	public class InputGeoPointConstructor : InputGeoPoint
	{
		public double lat;
		public double lng;

		public InputGeoPointConstructor()
		{

		}

		public InputGeoPointConstructor(double lat, double lng)
		{
			this.lat = lat;
			this.lng = lng;
		}


		public Constructor Constructor
		{
			get { return Constructor.inputGeoPoint; }
		}

		public override void Write(BinaryWriter writer)
		{
			writer.Write(0xf3b7acc9);
			writer.Write(this.lat);
			writer.Write(this.lng);
		}

		public override void Read(BinaryReader reader)
		{
			this.lat = reader.ReadDouble();
			this.lng = reader.ReadDouble();
		}

		public override string ToString()
		{
			return String.Format("(inputGeoPoint lat:{0} long:{1})", lat, lng);
		}
	}


	public class InputPhotoEmptyConstructor : InputPhoto
	{

		public InputPhotoEmptyConstructor()
		{

		}



		public Constructor Constructor
		{
			get { return Constructor.inputPhotoEmpty; }
		}

		public override void Write(BinaryWriter writer)
		{
			writer.Write(0x1cd7bf0d);
		}

		public override void Read(BinaryReader reader)
		{
		}

		public override string ToString()
		{
			return String.Format("(inputPhotoEmpty)");
		}
	}


	public class InputPhotoConstructor : InputPhoto
	{
		public long id;
		public long access_hash;

		public InputPhotoConstructor()
		{

		}

		public InputPhotoConstructor(long id, long access_hash)
		{
			this.id = id;
			this.access_hash = access_hash;
		}


		public Constructor Constructor
		{
			get { return Constructor.inputPhoto; }
		}

		public override void Write(BinaryWriter writer)
		{
			writer.Write(0xfb95c6c4);
			writer.Write(this.id);
			writer.Write(this.access_hash);
		}

		public override void Read(BinaryReader reader)
		{
			this.id = reader.ReadInt64();
			this.access_hash = reader.ReadInt64();
		}

		public override string ToString()
		{
			return String.Format("(inputPhoto id:{0} access_hash:{1})", id, access_hash);
		}
	}


	public class InputVideoEmptyConstructor : InputVideo
	{

		public InputVideoEmptyConstructor()
		{

		}



		public Constructor Constructor
		{
			get { return Constructor.inputVideoEmpty; }
		}

		public override void Write(BinaryWriter writer)
		{
			writer.Write(0x5508ec75);
		}

		public override void Read(BinaryReader reader)
		{
		}

		public override string ToString()
		{
			return String.Format("(inputVideoEmpty)");
		}
	}


	public class InputVideoConstructor : InputVideo
	{
		public long id;
		public long access_hash;

		public InputVideoConstructor()
		{

		}

		public InputVideoConstructor(long id, long access_hash)
		{
			this.id = id;
			this.access_hash = access_hash;
		}


		public Constructor Constructor
		{
			get { return Constructor.inputVideo; }
		}

		public override void Write(BinaryWriter writer)
		{
			writer.Write(0xee579652);
			writer.Write(this.id);
			writer.Write(this.access_hash);
		}

		public override void Read(BinaryReader reader)
		{
			this.id = reader.ReadInt64();
			this.access_hash = reader.ReadInt64();
		}

		public override string ToString()
		{
			return String.Format("(inputVideo id:{0} access_hash:{1})", id, access_hash);
		}
	}


	public class InputFileLocationConstructor : InputFileLocation
	{
		public long volume_id;
		public int local_id;
		public long secret;

		public InputFileLocationConstructor()
		{

		}

		public InputFileLocationConstructor(long volume_id, int local_id, long secret)
		{
			this.volume_id = volume_id;
			this.local_id = local_id;
			this.secret = secret;
		}


		public Constructor Constructor
		{
			get { return Constructor.inputFileLocation; }
		}

		public override void Write(BinaryWriter writer)
		{
			writer.Write(0x14637196);
			writer.Write(this.volume_id);
			writer.Write(this.local_id);
			writer.Write(this.secret);
		}

		public override void Read(BinaryReader reader)
		{
			this.volume_id = reader.ReadInt64();
			this.local_id = reader.ReadInt32();
			this.secret = reader.ReadInt64();
		}

		public override string ToString()
		{
			return String.Format("(inputFileLocation volume_id:{0} local_id:{1} secret:{2})", volume_id, local_id, secret);
		}
	}


	public class InputVideoFileLocationConstructor : InputFileLocation
	{
		public long id;
		public long access_hash;

		public InputVideoFileLocationConstructor()
		{

		}

		public InputVideoFileLocationConstructor(long id, long access_hash)
		{
			this.id = id;
			this.access_hash = access_hash;
		}


		public Constructor Constructor
		{
			get { return Constructor.inputVideoFileLocation; }
		}

		public override void Write(BinaryWriter writer)
		{
			writer.Write(0x3d0364ec);
			writer.Write(this.id);
			writer.Write(this.access_hash);
		}

		public override void Read(BinaryReader reader)
		{
			this.id = reader.ReadInt64();
			this.access_hash = reader.ReadInt64();
		}

		public override string ToString()
		{
			return String.Format("(inputVideoFileLocation id:{0} access_hash:{1})", id, access_hash);
		}
	}


	public class InputPhotoCropAutoConstructor : InputPhotoCrop
	{

		public InputPhotoCropAutoConstructor()
		{

		}



		public Constructor Constructor
		{
			get { return Constructor.inputPhotoCropAuto; }
		}

		public override void Write(BinaryWriter writer)
		{
			writer.Write(0xade6b004);
		}

		public override void Read(BinaryReader reader)
		{
		}

		public override string ToString()
		{
			return String.Format("(inputPhotoCropAuto)");
		}
	}


	public class InputPhotoCropConstructor : InputPhotoCrop
	{
		public double crop_left;
		public double crop_top;
		public double crop_width;

		public InputPhotoCropConstructor()
		{

		}

		public InputPhotoCropConstructor(double crop_left, double crop_top, double crop_width)
		{
			this.crop_left = crop_left;
			this.crop_top = crop_top;
			this.crop_width = crop_width;
		}


		public Constructor Constructor
		{
			get { return Constructor.inputPhotoCrop; }
		}

		public override void Write(BinaryWriter writer)
		{
			writer.Write(0xd9915325);
			writer.Write(this.crop_left);
			writer.Write(this.crop_top);
			writer.Write(this.crop_width);
		}

		public override void Read(BinaryReader reader)
		{
			this.crop_left = reader.ReadDouble();
			this.crop_top = reader.ReadDouble();
			this.crop_width = reader.ReadDouble();
		}

		public override string ToString()
		{
			return String.Format("(inputPhotoCrop crop_left:{0} crop_top:{1} crop_width:{2})", crop_left, crop_top, crop_width);
		}
	}


	public class InputAppEventConstructor : InputAppEvent
	{
		public double time;
		public string type;
		public long peer;
		public string data;

		public InputAppEventConstructor()
		{

		}

		public InputAppEventConstructor(double time, string type, long peer, string data)
		{
			this.time = time;
			this.type = type;
			this.peer = peer;
			this.data = data;
		}


		public Constructor Constructor
		{
			get { return Constructor.inputAppEvent; }
		}

		public override void Write(BinaryWriter writer)
		{
			writer.Write(0x770656a8);
			writer.Write(this.time);
			Serializers.String.write(writer, this.type);
			writer.Write(this.peer);
			Serializers.String.write(writer, this.data);
		}

		public override void Read(BinaryReader reader)
		{
			this.time = reader.ReadDouble();
			this.type = Serializers.String.read(reader);
			this.peer = reader.ReadInt64();
			this.data = Serializers.String.read(reader);
		}

		public override string ToString()
		{
			return String.Format("(inputAppEvent time:{0} type:'{1}' peer:{2} data:'{3}')", time, type, peer, data);
		}
	}


	public class PeerUserConstructor : Peer
	{
		public int user_id;

		public PeerUserConstructor()
		{

		}

		public PeerUserConstructor(int user_id)
		{
			this.user_id = user_id;
		}


		public Constructor Constructor
		{
			get { return Constructor.peerUser; }
		}

		public override void Write(BinaryWriter writer)
		{
			writer.Write(0x9db1bc6d);
			writer.Write(this.user_id);
		}

		public override void Read(BinaryReader reader)
		{
			this.user_id = reader.ReadInt32();
		}

		public override string ToString()
		{
			return String.Format("(peerUser user_id:{0})", user_id);
		}
	}


	public class PeerChatConstructor : Peer
	{
		public int chat_id;

		public PeerChatConstructor()
		{

		}

		public PeerChatConstructor(int chat_id)
		{
			this.chat_id = chat_id;
		}


		public Constructor Constructor
		{
			get { return Constructor.peerChat; }
		}

		public override void Write(BinaryWriter writer)
		{
			writer.Write(0xbad0e5bb);
			writer.Write(this.chat_id);
		}

		public override void Read(BinaryReader reader)
		{
			this.chat_id = reader.ReadInt32();
		}

		public override string ToString()
		{
			return String.Format("(peerChat chat_id:{0})", chat_id);
		}
	}


	public class Storage_fileUnknownConstructor : storage_FileType
	{

		public Storage_fileUnknownConstructor()
		{

		}



		public Constructor Constructor
		{
			get { return Constructor.storage_fileUnknown; }
		}

		public override void Write(BinaryWriter writer)
		{
			writer.Write(0xaa963b05);
		}

		public override void Read(BinaryReader reader)
		{
		}

		public override string ToString()
		{
			return String.Format("(storage_fileUnknown)");
		}
	}


	public class Storage_fileJpegConstructor : storage_FileType
	{

		public Storage_fileJpegConstructor()
		{

		}



		public Constructor Constructor
		{
			get { return Constructor.storage_fileJpeg; }
		}

		public override void Write(BinaryWriter writer)
		{
			writer.Write(0x007efe0e);
		}

		public override void Read(BinaryReader reader)
		{
		}

		public override string ToString()
		{
			return String.Format("(storage_fileJpeg)");
		}
	}


	public class Storage_fileGifConstructor : storage_FileType
	{

		public Storage_fileGifConstructor()
		{

		}



		public Constructor Constructor
		{
			get { return Constructor.storage_fileGif; }
		}

		public override void Write(BinaryWriter writer)
		{
			writer.Write(0xcae1aadf);
		}

		public override void Read(BinaryReader reader)
		{
		}

		public override string ToString()
		{
			return String.Format("(storage_fileGif)");
		}
	}


	public class Storage_filePngConstructor : storage_FileType
	{

		public Storage_filePngConstructor()
		{

		}



		public Constructor Constructor
		{
			get { return Constructor.storage_filePng; }
		}

		public override void Write(BinaryWriter writer)
		{
			writer.Write(0x0a4f63c0);
		}

		public override void Read(BinaryReader reader)
		{
		}

		public override string ToString()
		{
			return String.Format("(storage_filePng)");
		}
	}


	public class Storage_fileMp3Constructor : storage_FileType
	{

		public Storage_fileMp3Constructor()
		{

		}



		public Constructor Constructor
		{
			get { return Constructor.storage_fileMp3; }
		}

		public override void Write(BinaryWriter writer)
		{
			writer.Write(0x528a0677);
		}

		public override void Read(BinaryReader reader)
		{
		}

		public override string ToString()
		{
			return String.Format("(storage_fileMp3)");
		}
	}


	public class Storage_fileMovConstructor : storage_FileType
	{

		public Storage_fileMovConstructor()
		{

		}



		public Constructor Constructor
		{
			get { return Constructor.storage_fileMov; }
		}

		public override void Write(BinaryWriter writer)
		{
			writer.Write(0x4b09ebbc);
		}

		public override void Read(BinaryReader reader)
		{
		}

		public override string ToString()
		{
			return String.Format("(storage_fileMov)");
		}
	}


	public class Storage_filePartialConstructor : storage_FileType
	{

		public Storage_filePartialConstructor()
		{

		}



		public Constructor Constructor
		{
			get { return Constructor.storage_filePartial; }
		}

		public override void Write(BinaryWriter writer)
		{
			writer.Write(0x40bc6f52);
		}

		public override void Read(BinaryReader reader)
		{
		}

		public override string ToString()
		{
			return String.Format("(storage_filePartial)");
		}
	}


	public class Storage_fileMp4Constructor : storage_FileType
	{

		public Storage_fileMp4Constructor()
		{

		}



		public Constructor Constructor
		{
			get { return Constructor.storage_fileMp4; }
		}

		public override void Write(BinaryWriter writer)
		{
			writer.Write(0xb3cea0e4);
		}

		public override void Read(BinaryReader reader)
		{
		}

		public override string ToString()
		{
			return String.Format("(storage_fileMp4)");
		}
	}


	public class Storage_fileWebpConstructor : storage_FileType
	{

		public Storage_fileWebpConstructor()
		{

		}



		public Constructor Constructor
		{
			get { return Constructor.storage_fileWebp; }
		}

		public override void Write(BinaryWriter writer)
		{
			writer.Write(0x1081464c);
		}

		public override void Read(BinaryReader reader)
		{
		}

		public override string ToString()
		{
			return String.Format("(storage_fileWebp)");
		}
	}


	public class FileLocationUnavailableConstructor : FileLocation
	{
		public long volume_id;
		public int local_id;
		public long secret;

		public FileLocationUnavailableConstructor()
		{

		}

		public FileLocationUnavailableConstructor(long volume_id, int local_id, long secret)
		{
			this.volume_id = volume_id;
			this.local_id = local_id;
			this.secret = secret;
		}


		public Constructor Constructor
		{
			get { return Constructor.fileLocationUnavailable; }
		}

		public override void Write(BinaryWriter writer)
		{
			writer.Write(0x7c596b46);
			writer.Write(this.volume_id);
			writer.Write(this.local_id);
			writer.Write(this.secret);
		}

		public override void Read(BinaryReader reader)
		{
			this.volume_id = reader.ReadInt64();
			this.local_id = reader.ReadInt32();
			this.secret = reader.ReadInt64();
		}

		public override string ToString()
		{
			return String.Format("(fileLocationUnavailable volume_id:{0} local_id:{1} secret:{2})", volume_id, local_id, secret);
		}
	}


	public class FileLocationConstructor : FileLocation
	{
		public int dc_id;
		public long volume_id;
		public int local_id;
		public long secret;

		public FileLocationConstructor()
		{

		}

		public FileLocationConstructor(int dc_id, long volume_id, int local_id, long secret)
		{
			this.dc_id = dc_id;
			this.volume_id = volume_id;
			this.local_id = local_id;
			this.secret = secret;
		}


		public Constructor Constructor
		{
			get { return Constructor.fileLocation; }
		}

		public override void Write(BinaryWriter writer)
		{
			writer.Write(0x53d69076);
			writer.Write(this.dc_id);
			writer.Write(this.volume_id);
			writer.Write(this.local_id);
			writer.Write(this.secret);
		}

		public override void Read(BinaryReader reader)
		{
			this.dc_id = reader.ReadInt32();
			this.volume_id = reader.ReadInt64();
			this.local_id = reader.ReadInt32();
			this.secret = reader.ReadInt64();
		}

		public override string ToString()
		{
			return String.Format("(fileLocation dc_id:{0} volume_id:{1} local_id:{2} secret:{3})", dc_id, volume_id, local_id,
				secret);
		}
	}


	public class UserEmptyConstructor : User
	{
		public int id;

		public UserEmptyConstructor()
		{

		}

		public UserEmptyConstructor(int id)
		{
			this.id = id;
		}


		public Constructor Constructor
		{
			get { return Constructor.userEmpty; }
		}

		public override void Write(BinaryWriter writer)
		{
			writer.Write(0x200250ba);
			writer.Write(this.id);
		}

		public override void Read(BinaryReader reader)
		{
			this.id = reader.ReadInt32();
		}

		public override string ToString()
		{
			return String.Format("(userEmpty id:{0})", id);
		}
	}


	public class UserSelfConstructor : User
	{
		public int id;
		public string first_name;
		public string last_name;
		public string phone;
		public UserProfilePhoto photo;
		public UserStatus status;
		public bool inactive;

		public UserSelfConstructor()
		{

		}

		public UserSelfConstructor(int id, string first_name, string last_name, string phone, UserProfilePhoto photo,
			UserStatus status, bool inactive)
		{
			this.id = id;
			this.first_name = first_name;
			this.last_name = last_name;
			this.phone = phone;
			this.photo = photo;
			this.status = status;
			this.inactive = inactive;
		}


		public Constructor Constructor
		{
			get { return Constructor.userSelf; }
		}

		public override void Write(BinaryWriter writer)
		{
			writer.Write(0x720535ec);
			writer.Write(this.id);
			Serializers.String.write(writer, this.first_name);
			Serializers.String.write(writer, this.last_name);
			Serializers.String.write(writer, this.phone);
			//this.photo.Write(writer);
			//this.status.Write(writer);
			writer.Write(this.inactive ? 0x997275b5 : 0xbc799737);
		}

		public override void Read(BinaryReader reader)
		{
			this.id = reader.ReadInt32();
			this.first_name = Serializers.String.read(reader);
			this.last_name = Serializers.String.read(reader);
			this.phone = Serializers.String.read(reader);
			//this.photo = TL.Parse<UserProfilePhoto>(reader);
			//this.status = TL.Parse<UserStatus>(reader);
			this.inactive = reader.ReadUInt32() == 0x997275b5;
		}

		public override string ToString()
		{
			return
				String.Format("(userSelf id:{0} first_name:'{1}' last_name:'{2}' phone:'{3}' photo:{4} status:{5} inactive:{6})", id,
					first_name, last_name, phone, photo, status, inactive);
		}
	}


	public class UserContactConstructor : User
	{
		public int id;
		public string first_name;
		public string last_name;
		public long access_hash;
		public string phone;
		public UserProfilePhoto photo;
		public UserStatus status;

		public UserContactConstructor()
		{

		}

		public UserContactConstructor(int id, string first_name, string last_name, long access_hash, string phone,
			UserProfilePhoto photo, UserStatus status)
		{
			this.id = id;
			this.first_name = first_name;
			this.last_name = last_name;
			this.access_hash = access_hash;
			this.phone = phone;
			this.photo = photo;
			this.status = status;
		}


		public Constructor Constructor
		{
			get { return Constructor.userContact; }
		}

		public override void Write(BinaryWriter writer)
		{
			writer.Write(0xf2fb8319);
			writer.Write(this.id);
			Serializers.String.write(writer, this.first_name);
			Serializers.String.write(writer, this.last_name);
			writer.Write(this.access_hash);
			Serializers.String.write(writer, this.phone);
			this.photo.Write(writer);
			this.status.Write(writer);
		}

		public override void Read(BinaryReader reader)
		{
			this.id = reader.ReadInt32();
			this.first_name = Serializers.String.read(reader);
			this.last_name = Serializers.String.read(reader);
			this.access_hash = reader.ReadInt64();
			this.phone = Serializers.String.read(reader);
			this.photo = TL.Parse<UserProfilePhoto>(reader);
			this.status = TL.Parse<UserStatus>(reader);
		}

		public override string ToString()
		{
			return
				String.Format(
					"(userContact id:{0} first_name:'{1}' last_name:'{2}' access_hash:{3} phone:'{4}' photo:{5} status:{6})", id,
					first_name, last_name, access_hash, phone, photo, status);
		}
	}


	public class UserRequestConstructor : User
	{
		public int id;
		public string first_name;
		public string last_name;
		public long access_hash;
		public string phone;
		public UserProfilePhoto photo;
		public UserStatus status;

		public UserRequestConstructor()
		{

		}

		public UserRequestConstructor(int id, string first_name, string last_name, long access_hash, string phone,
			UserProfilePhoto photo, UserStatus status)
		{
			this.id = id;
			this.first_name = first_name;
			this.last_name = last_name;
			this.access_hash = access_hash;
			this.phone = phone;
			this.photo = photo;
			this.status = status;
		}


		public Constructor Constructor
		{
			get { return Constructor.userRequest; }
		}

		public override void Write(BinaryWriter writer)
		{
			writer.Write(0x22e8ceb0);
			writer.Write(this.id);
			Serializers.String.write(writer, this.first_name);
			Serializers.String.write(writer, this.last_name);
			writer.Write(this.access_hash);
			Serializers.String.write(writer, this.phone);
			this.photo.Write(writer);
			this.status.Write(writer);
		}

		public override void Read(BinaryReader reader)
		{
			this.id = reader.ReadInt32();
			this.first_name = Serializers.String.read(reader);
			this.last_name = Serializers.String.read(reader);
			this.access_hash = reader.ReadInt64();
			this.phone = Serializers.String.read(reader);
			this.photo = TL.Parse<UserProfilePhoto>(reader);
			this.status = TL.Parse<UserStatus>(reader);
		}

		public override string ToString()
		{
			return
				String.Format(
					"(userRequest id:{0} first_name:'{1}' last_name:'{2}' access_hash:{3} phone:'{4}' photo:{5} status:{6})", id,
					first_name, last_name, access_hash, phone, photo, status);
		}
	}


	public class UserForeignConstructor : User
	{
		public int id;
		public string first_name;
		public string last_name;
		public long access_hash;
		public UserProfilePhoto photo;
		public UserStatus status;

		public UserForeignConstructor()
		{

		}

		public UserForeignConstructor(int id, string first_name, string last_name, long access_hash, UserProfilePhoto photo,
			UserStatus status)
		{
			this.id = id;
			this.first_name = first_name;
			this.last_name = last_name;
			this.access_hash = access_hash;
			this.photo = photo;
			this.status = status;
		}


		public Constructor Constructor
		{
			get { return Constructor.userForeign; }
		}

		public override void Write(BinaryWriter writer)
		{
			writer.Write(0x5214c89d);
			writer.Write(this.id);
			Serializers.String.write(writer, this.first_name);
			Serializers.String.write(writer, this.last_name);
			writer.Write(this.access_hash);
			this.photo.Write(writer);
			this.status.Write(writer);
		}

		public override void Read(BinaryReader reader)
		{
			this.id = reader.ReadInt32();
			this.first_name = Serializers.String.read(reader);
			this.last_name = Serializers.String.read(reader);
			this.access_hash = reader.ReadInt64();
			this.photo = TL.Parse<UserProfilePhoto>(reader);
			this.status = TL.Parse<UserStatus>(reader);
		}

		public override string ToString()
		{
			return String.Format("(userForeign id:{0} first_name:'{1}' last_name:'{2}' access_hash:{3} photo:{4} status:{5})", id,
				first_name, last_name, access_hash, photo, status);
		}
	}


	public class UserDeletedConstructor : User
	{
		public int id;
		public string first_name;
		public string last_name;

		public UserDeletedConstructor()
		{

		}

		public UserDeletedConstructor(int id, string first_name, string last_name)
		{
			this.id = id;
			this.first_name = first_name;
			this.last_name = last_name;
		}


		public Constructor Constructor
		{
			get { return Constructor.userDeleted; }
		}

		public override void Write(BinaryWriter writer)
		{
			writer.Write(0xb29ad7cc);
			writer.Write(this.id);
			Serializers.String.write(writer, this.first_name);
			Serializers.String.write(writer, this.last_name);
		}

		public override void Read(BinaryReader reader)
		{
			this.id = reader.ReadInt32();
			this.first_name = Serializers.String.read(reader);
			this.last_name = Serializers.String.read(reader);
		}

		public override string ToString()
		{
			return String.Format("(userDeleted id:{0} first_name:'{1}' last_name:'{2}')", id, first_name, last_name);
		}
	}


	public class UserProfilePhotoEmptyConstructor : UserProfilePhoto
	{

		public UserProfilePhotoEmptyConstructor()
		{

		}



		public Constructor Constructor
		{
			get { return Constructor.userProfilePhotoEmpty; }
		}

		public override void Write(BinaryWriter writer)
		{
			writer.Write(0x4f11bae1);
		}

		public override void Read(BinaryReader reader)
		{
		}

		public override string ToString()
		{
			return String.Format("(userProfilePhotoEmpty)");
		}
	}


	public class UserProfilePhotoConstructor : UserProfilePhoto
	{
		public long photo_id;
		public FileLocation photo_small;
		public FileLocation photo_big;

		public UserProfilePhotoConstructor()
		{

		}

		public UserProfilePhotoConstructor(long photo_id, FileLocation photo_small, FileLocation photo_big)
		{
			this.photo_id = photo_id;
			this.photo_small = photo_small;
			this.photo_big = photo_big;
		}


		public Constructor Constructor
		{
			get { return Constructor.userProfilePhoto; }
		}

		public override void Write(BinaryWriter writer)
		{
			writer.Write(0xd559d8c8);
			writer.Write(this.photo_id);
			this.photo_small.Write(writer);
			this.photo_big.Write(writer);
		}

		public override void Read(BinaryReader reader)
		{
			this.photo_id = reader.ReadInt64();
			this.photo_small = TL.Parse<FileLocation>(reader);
			this.photo_big = TL.Parse<FileLocation>(reader);
		}

		public override string ToString()
		{
			return String.Format("(userProfilePhoto photo_id:{0} photo_small:{1} photo_big:{2})", photo_id, photo_small,
				photo_big);
		}
	}


	public class UserStatusEmptyConstructor : UserStatus
	{

		public UserStatusEmptyConstructor()
		{

		}



		public Constructor Constructor
		{
			get { return Constructor.userStatusEmpty; }
		}

		public override void Write(BinaryWriter writer)
		{
			writer.Write(0x09d05049);
		}

		public override void Read(BinaryReader reader)
		{
		}

		public override string ToString()
		{
			return String.Format("(userStatusEmpty)");
		}
	}


	public class UserStatusOnlineConstructor : UserStatus
	{
		public int expires;

		public UserStatusOnlineConstructor()
		{

		}

		public UserStatusOnlineConstructor(int expires)
		{
			this.expires = expires;
		}


		public Constructor Constructor
		{
			get { return Constructor.userStatusOnline; }
		}

		public override void Write(BinaryWriter writer)
		{
			writer.Write(0xedb93949);
			writer.Write(this.expires);
		}

		public override void Read(BinaryReader reader)
		{
			this.expires = reader.ReadInt32();
		}

		public override string ToString()
		{
			return String.Format("(userStatusOnline expires:{0})", expires);
		}
	}


	public class UserStatusOfflineConstructor : UserStatus
	{
		public int was_online;

		public UserStatusOfflineConstructor()
		{

		}

		public UserStatusOfflineConstructor(int was_online)
		{
			this.was_online = was_online;
		}


		public Constructor Constructor
		{
			get { return Constructor.userStatusOffline; }
		}

		public override void Write(BinaryWriter writer)
		{
			writer.Write(0x008c703f);
			writer.Write(this.was_online);
		}

		public override void Read(BinaryReader reader)
		{
			this.was_online = reader.ReadInt32();
		}

		public override string ToString()
		{
			return String.Format("(userStatusOffline was_online:{0})", was_online);
		}
	}


	public class ChatEmptyConstructor : Chat
	{
		public int id;

		public ChatEmptyConstructor()
		{

		}

		public ChatEmptyConstructor(int id)
		{
			this.id = id;
		}


		public Constructor Constructor
		{
			get { return Constructor.chatEmpty; }
		}

		public override void Write(BinaryWriter writer)
		{
			writer.Write(0x9ba2d800);
			writer.Write(this.id);
		}

		public override void Read(BinaryReader reader)
		{
			this.id = reader.ReadInt32();
		}

		public override string ToString()
		{
			return String.Format("(chatEmpty id:{0})", id);
		}
	}


	public class ChatConstructor : Chat
	{
		public int id;
		public string title;
		public ChatPhoto photo;
		public int participants_count;
		public int date;
		public bool left;
		public int version;

		public ChatConstructor()
		{

		}

		public ChatConstructor(int id, string title, ChatPhoto photo, int participants_count, int date, bool left, int version)
		{
			this.id = id;
			this.title = title;
			this.photo = photo;
			this.participants_count = participants_count;
			this.date = date;
			this.left = left;
			this.version = version;
		}


		public Constructor Constructor
		{
			get { return Constructor.chat; }
		}

		public override void Write(BinaryWriter writer)
		{
			writer.Write(0x6e9c9bc7);
			writer.Write(this.id);
			Serializers.String.write(writer, this.title);
			this.photo.Write(writer);
			writer.Write(this.participants_count);
			writer.Write(this.date);
			writer.Write(this.left ? 0x997275b5 : 0xbc799737);
			writer.Write(this.version);
		}

		public override void Read(BinaryReader reader)
		{
			this.id = reader.ReadInt32();
			this.title = Serializers.String.read(reader);
			this.photo = TL.Parse<ChatPhoto>(reader);
			this.participants_count = reader.ReadInt32();
			this.date = reader.ReadInt32();
			this.left = reader.ReadUInt32() == 0x997275b5;
			this.version = reader.ReadInt32();
		}

		public override string ToString()
		{
			return String.Format("(chat id:{0} title:'{1}' photo:{2} participants_count:{3} date:{4} left:{5} version:{6})", id,
				title, photo, participants_count, date, left, version);
		}
	}


	public class ChatForbiddenConstructor : Chat
	{
		public int id;
		public string title;
		public int date;

		public ChatForbiddenConstructor()
		{

		}

		public ChatForbiddenConstructor(int id, string title, int date)
		{
			this.id = id;
			this.title = title;
			this.date = date;
		}


		public Constructor Constructor
		{
			get { return Constructor.chatForbidden; }
		}

		public override void Write(BinaryWriter writer)
		{
			writer.Write(0xfb0ccc41);
			writer.Write(this.id);
			Serializers.String.write(writer, this.title);
			writer.Write(this.date);
		}

		public override void Read(BinaryReader reader)
		{
			this.id = reader.ReadInt32();
			this.title = Serializers.String.read(reader);
			this.date = reader.ReadInt32();
		}

		public override string ToString()
		{
			return String.Format("(chatForbidden id:{0} title:'{1}' date:{2})", id, title, date);
		}
	}


	public class ChatFullConstructor : ChatFull
	{
		public int id;
		public ChatParticipants participants;
		public Photo chat_photo;
		public PeerNotifySettings notify_settings;

		public ChatFullConstructor()
		{

		}

		public ChatFullConstructor(int id, ChatParticipants participants, Photo chat_photo, PeerNotifySettings notify_settings)
		{
			this.id = id;
			this.participants = participants;
			this.chat_photo = chat_photo;
			this.notify_settings = notify_settings;
		}


		public Constructor Constructor
		{
			get { return Constructor.chatFull; }
		}

		public override void Write(BinaryWriter writer)
		{
			writer.Write(0x630e61be);
			writer.Write(this.id);
			this.participants.Write(writer);
			this.chat_photo.Write(writer);
			this.notify_settings.Write(writer);
		}

		public override void Read(BinaryReader reader)
		{
			this.id = reader.ReadInt32();
			this.participants = TL.Parse<ChatParticipants>(reader);
			this.chat_photo = TL.Parse<Photo>(reader);
			this.notify_settings = TL.Parse<PeerNotifySettings>(reader);
		}

		public override string ToString()
		{
			return String.Format("(chatFull id:{0} participants:{1} chat_photo:{2} notify_settings:{3})", id, participants,
				chat_photo, notify_settings);
		}
	}


	public class ChatParticipantConstructor : ChatParticipant
	{
		public int user_id;
		public int inviter_id;
		public int date;

		public ChatParticipantConstructor()
		{

		}

		public ChatParticipantConstructor(int user_id, int inviter_id, int date)
		{
			this.user_id = user_id;
			this.inviter_id = inviter_id;
			this.date = date;
		}


		public Constructor Constructor
		{
			get { return Constructor.chatParticipant; }
		}

		public override void Write(BinaryWriter writer)
		{
			writer.Write(0xc8d7493e);
			writer.Write(this.user_id);
			writer.Write(this.inviter_id);
			writer.Write(this.date);
		}

		public override void Read(BinaryReader reader)
		{
			this.user_id = reader.ReadInt32();
			this.inviter_id = reader.ReadInt32();
			this.date = reader.ReadInt32();
		}

		public override string ToString()
		{
			return String.Format("(chatParticipant user_id:{0} inviter_id:{1} date:{2})", user_id, inviter_id, date);
		}
	}


	public class ChatParticipantsForbiddenConstructor : ChatParticipants
	{
		public int chat_id;

		public ChatParticipantsForbiddenConstructor()
		{

		}

		public ChatParticipantsForbiddenConstructor(int chat_id)
		{
			this.chat_id = chat_id;
		}


		public Constructor Constructor
		{
			get { return Constructor.chatParticipantsForbidden; }
		}

		public override void Write(BinaryWriter writer)
		{
			writer.Write(0x0fd2bb8a);
			writer.Write(this.chat_id);
		}

		public override void Read(BinaryReader reader)
		{
			this.chat_id = reader.ReadInt32();
		}

		public override string ToString()
		{
			return String.Format("(chatParticipantsForbidden chat_id:{0})", chat_id);
		}
	}


	public class ChatParticipantsConstructor : ChatParticipants
	{
		public int chat_id;
		public int admin_id;
		public List<ChatParticipant> participants;
		public int version;

		public ChatParticipantsConstructor()
		{

		}

		public ChatParticipantsConstructor(int chat_id, int admin_id, List<ChatParticipant> participants, int version)
		{
			this.chat_id = chat_id;
			this.admin_id = admin_id;
			this.participants = participants;
			this.version = version;
		}


		public Constructor Constructor
		{
			get { return Constructor.chatParticipants; }
		}

		public override void Write(BinaryWriter writer)
		{
			writer.Write(0x7841b415);
			writer.Write(this.chat_id);
			writer.Write(this.admin_id);
			writer.Write(0x1cb5c415);
			writer.Write(this.participants.Count);
			foreach (ChatParticipant participants_element in this.participants)
			{
				participants_element.Write(writer);
			}
			writer.Write(this.version);
		}

		public override void Read(BinaryReader reader)
		{
			this.chat_id = reader.ReadInt32();
			this.admin_id = reader.ReadInt32();
			reader.ReadInt32(); // vector code
			int participants_len = reader.ReadInt32();
			this.participants = new List<ChatParticipant>(participants_len);
			for (int participants_index = 0; participants_index < participants_len; participants_index++)
			{
				ChatParticipant participants_element;
				participants_element = TL.Parse<ChatParticipant>(reader);
				this.participants.Add(participants_element);
			}
			this.version = reader.ReadInt32();
		}

		public override string ToString()
		{
			return String.Format("(chatParticipants chat_id:{0} admin_id:{1} participants:{2} version:{3})", chat_id, admin_id,
				Serializers.VectorToString(participants), version);
		}
	}


	public class ChatPhotoEmptyConstructor : ChatPhoto
	{

		public ChatPhotoEmptyConstructor()
		{

		}



		public Constructor Constructor
		{
			get { return Constructor.chatPhotoEmpty; }
		}

		public override void Write(BinaryWriter writer)
		{
			writer.Write(0x37c1011c);
		}

		public override void Read(BinaryReader reader)
		{
		}

		public override string ToString()
		{
			return String.Format("(chatPhotoEmpty)");
		}
	}


	public class ChatPhotoConstructor : ChatPhoto
	{
		public FileLocation photo_small;
		public FileLocation photo_big;

		public ChatPhotoConstructor()
		{

		}

		public ChatPhotoConstructor(FileLocation photo_small, FileLocation photo_big)
		{
			this.photo_small = photo_small;
			this.photo_big = photo_big;
		}


		public Constructor Constructor
		{
			get { return Constructor.chatPhoto; }
		}

		public override void Write(BinaryWriter writer)
		{
			writer.Write(0x6153276a);
			this.photo_small.Write(writer);
			this.photo_big.Write(writer);
		}

		public override void Read(BinaryReader reader)
		{
			this.photo_small = TL.Parse<FileLocation>(reader);
			this.photo_big = TL.Parse<FileLocation>(reader);
		}

		public override string ToString()
		{
			return String.Format("(chatPhoto photo_small:{0} photo_big:{1})", photo_small, photo_big);
		}
	}


	public class MessageEmptyConstructor : Message
	{
		public int id;

		public MessageEmptyConstructor()
		{

		}

		public MessageEmptyConstructor(int id)
		{
			this.id = id;
		}


		public Constructor Constructor
		{
			get { return Constructor.messageEmpty; }
		}

		public override void Write(BinaryWriter writer)
		{
			writer.Write(0x83e5de54);
			writer.Write(this.id);
		}

		public override void Read(BinaryReader reader)
		{
			this.id = reader.ReadInt32();
		}

		public override string ToString()
		{
			return String.Format("(messageEmpty id:{0})", id);
		}
	}


    public class MessageForwardedConstructor : Message
	{
		public int id;
		public int fwd_from_id;
		public int fwd_date;
		public int from_id;
		public int to_id;
		public bool output;
		public bool unread;
		public int date;
		public string message;
		public MessageMedia media;

		public MessageForwardedConstructor()
		{

		}

		public MessageForwardedConstructor(int id, int fwd_from_id, int fwd_date, int from_id, int to_id, bool output,
			bool unread, int date, string message, MessageMedia media)
		{
			this.id = id;
			this.fwd_from_id = fwd_from_id;
			this.fwd_date = fwd_date;
			this.from_id = from_id;
			this.to_id = to_id;
			this.output = output;
			this.unread = unread;
			this.date = date;
			this.message = message;
			this.media = media;
		}


		public Constructor Constructor
		{
			get { return Constructor.messageForwarded; }
		}

		public override void Write(BinaryWriter writer)
		{
			writer.Write(0x05f46804);
			writer.Write(this.id);
			writer.Write(this.fwd_from_id);
			writer.Write(this.fwd_date);
			writer.Write(this.from_id);
			writer.Write(this.to_id);
			writer.Write(this.output ? 0x997275b5 : 0xbc799737);
			writer.Write(this.unread ? 0x997275b5 : 0xbc799737);
			writer.Write(this.date);
			Serializers.String.write(writer, this.message);
			this.media.Write(writer);
		}

		public override void Read(BinaryReader reader)
		{
			this.id = reader.ReadInt32();
			this.fwd_from_id = reader.ReadInt32();
			this.fwd_date = reader.ReadInt32();
			this.from_id = reader.ReadInt32();
			this.to_id = reader.ReadInt32();
			this.output = reader.ReadUInt32() == 0x997275b5;
			this.unread = reader.ReadUInt32() == 0x997275b5;
			this.date = reader.ReadInt32();
			this.message = Serializers.String.read(reader);
			this.media = TL.Parse<MessageMedia>(reader);
		}

		public override string ToString()
		{
			return
				String.Format(
					"(messageForwarded id:{0} fwd_from_id:{1} fwd_date:{2} from_id:{3} to_id:{4} out:{5} unread:{6} date:{7} message:'{8}' media:{9})",
					id, fwd_from_id, fwd_date, from_id, to_id, output, unread, date, message, media);
		}
	}


	public class MessageServiceConstructor : Message
	{
		public int id;
		public int from_id;
		public Peer to_id;
		public bool output;
		public bool unread;
		public int date;
		public MessageAction action;

		public MessageServiceConstructor()
		{

		}

		public MessageServiceConstructor(int id, int from_id, Peer to_id, bool output, bool unread, int date,
			MessageAction action)
		{
			this.id = id;
			this.from_id = from_id;
			this.to_id = to_id;
			this.output = output;
			this.unread = unread;
			this.date = date;
			this.action = action;
		}


		public Constructor Constructor
		{
			get { return Constructor.messageService; }
		}

		public override void Write(BinaryWriter writer)
		{
			writer.Write(0x9f8d60bb);
			writer.Write(this.id);
			writer.Write(this.from_id);
			this.to_id.Write(writer);
			writer.Write(this.output ? 0x997275b5 : 0xbc799737);
			writer.Write(this.unread ? 0x997275b5 : 0xbc799737);
			writer.Write(this.date);
			this.action.Write(writer);
		}

		public override void Read(BinaryReader reader)
		{
			this.id = reader.ReadInt32();
			this.from_id = reader.ReadInt32();
			this.to_id = TL.Parse<Peer>(reader);
			this.output = reader.ReadUInt32() == 0x997275b5;
			this.unread = reader.ReadUInt32() == 0x997275b5;
			this.date = reader.ReadInt32();
			this.action = TL.Parse<MessageAction>(reader);
		}

		public override string ToString()
		{
			return String.Format("(messageService id:{0} from_id:{1} to_id:{2} out:{3} unread:{4} date:{5} action:{6})", id,
				from_id, to_id, output, unread, date, action);
		}
	}


	public class MessageMediaEmptyConstructor : MessageMedia
	{

		public MessageMediaEmptyConstructor()
		{

		}



		public Constructor Constructor
		{
			get { return Constructor.messageMediaEmpty; }
		}

		public override void Write(BinaryWriter writer)
		{
			writer.Write(0x3ded6320);
		}

		public override void Read(BinaryReader reader)
		{
		}

		public override string ToString()
		{
			return String.Format("(messageMediaEmpty)");
		}
	}


	public class MessageMediaPhotoConstructor : MessageMedia
	{
		public Photo photo;

		public MessageMediaPhotoConstructor()
		{

		}

		public MessageMediaPhotoConstructor(Photo photo)
		{
			this.photo = photo;
		}


		public Constructor Constructor
		{
			get { return Constructor.messageMediaPhoto; }
		}

		public override void Write(BinaryWriter writer)
		{
			writer.Write(0xc8c45a2a);
			this.photo.Write(writer);
		}

		public override void Read(BinaryReader reader)
		{
			this.photo = TL.Parse<Photo>(reader);
		}

		public override string ToString()
		{
			return String.Format("(messageMediaPhoto photo:{0})", photo);
		}
	}


	public class MessageMediaVideoConstructor : MessageMedia
	{
		public Video video;

		public MessageMediaVideoConstructor()
		{

		}

		public MessageMediaVideoConstructor(Video video)
		{
			this.video = video;
		}


		public Constructor Constructor
		{
			get { return Constructor.messageMediaVideo; }
		}

		public override void Write(BinaryWriter writer)
		{
			writer.Write(0xa2d24290);
			this.video.Write(writer);
		}

		public override void Read(BinaryReader reader)
		{
			this.video = TL.Parse<Video>(reader);
		}

		public override string ToString()
		{
			return String.Format("(messageMediaVideo video:{0})", video);
		}
	}


	public class MessageMediaGeoConstructor : MessageMedia
	{
		public GeoPoint geo;

		public MessageMediaGeoConstructor()
		{

		}

		public MessageMediaGeoConstructor(GeoPoint geo)
		{
			this.geo = geo;
		}


		public Constructor Constructor
		{
			get { return Constructor.messageMediaGeo; }
		}

		public override void Write(BinaryWriter writer)
		{
			writer.Write(0x56e0d474);
			this.geo.Write(writer);
		}

		public override void Read(BinaryReader reader)
		{
			this.geo = TL.Parse<GeoPoint>(reader);
		}

		public override string ToString()
		{
			return String.Format("(messageMediaGeo geo:{0})", geo);
		}
	}


	public class MessageMediaContactConstructor : MessageMedia
	{
		public string phone_number;
		public string first_name;
		public string last_name;
		public int user_id;

		public MessageMediaContactConstructor()
		{

		}

		public MessageMediaContactConstructor(string phone_number, string first_name, string last_name, int user_id)
		{
			this.phone_number = phone_number;
			this.first_name = first_name;
			this.last_name = last_name;
			this.user_id = user_id;
		}


		public Constructor Constructor
		{
			get { return Constructor.messageMediaContact; }
		}

		public override void Write(BinaryWriter writer)
		{
			writer.Write(0x5e7d2f39);
			Serializers.String.write(writer, this.phone_number);
			Serializers.String.write(writer, this.first_name);
			Serializers.String.write(writer, this.last_name);
			writer.Write(this.user_id);
		}

		public override void Read(BinaryReader reader)
		{
			this.phone_number = Serializers.String.read(reader);
			this.first_name = Serializers.String.read(reader);
			this.last_name = Serializers.String.read(reader);
			this.user_id = reader.ReadInt32();
		}

		public override string ToString()
		{
			return String.Format("(messageMediaContact phone_number:'{0}' first_name:'{1}' last_name:'{2}' user_id:{3})",
				phone_number, first_name, last_name, user_id);
		}
	}


	public class MessageMediaUnsupportedConstructor : MessageMedia
	{
		public byte[] bytes;

		public MessageMediaUnsupportedConstructor()
		{

		}

		public MessageMediaUnsupportedConstructor(byte[] bytes)
		{
			this.bytes = bytes;
		}


		public Constructor Constructor
		{
			get { return Constructor.messageMediaUnsupported; }
		}

		public override void Write(BinaryWriter writer)
		{
			writer.Write(0x29632a36);
			Serializers.Bytes.write(writer, this.bytes);
		}

		public override void Read(BinaryReader reader)
		{
			this.bytes = Serializers.Bytes.read(reader);
		}

		public override string ToString()
		{
			return String.Format("(messageMediaUnsupported bytes:{0})", BitConverter.ToString(bytes));
		}
	}


	public class MessageActionEmptyConstructor : MessageAction
	{

		public MessageActionEmptyConstructor()
		{

		}



		public Constructor Constructor
		{
			get { return Constructor.messageActionEmpty; }
		}

		public override void Write(BinaryWriter writer)
		{
			writer.Write(0xb6aef7b0);
		}

		public override void Read(BinaryReader reader)
		{
		}

		public override string ToString()
		{
			return String.Format("(messageActionEmpty)");
		}
	}


	public class MessageActionChatCreateConstructor : MessageAction
	{
		public string title;
		public List<int> users;

		public MessageActionChatCreateConstructor()
		{

		}

		public MessageActionChatCreateConstructor(string title, List<int> users)
		{
			this.title = title;
			this.users = users;
		}


		public Constructor Constructor
		{
			get { return Constructor.messageActionChatCreate; }
		}

		public override void Write(BinaryWriter writer)
		{
			writer.Write(0xa6638b9a);
			Serializers.String.write(writer, this.title);
			writer.Write(0x1cb5c415);
			writer.Write(this.users.Count);
			foreach (int users_element in this.users)
			{
				writer.Write(users_element);
			}
		}

		public override void Read(BinaryReader reader)
		{
			this.title = Serializers.String.read(reader);
			reader.ReadInt32(); // vector code
			int users_len = reader.ReadInt32();
			this.users = new List<int>(users_len);
			for (int users_index = 0; users_index < users_len; users_index++)
			{
				int users_element;
				users_element = reader.ReadInt32();
				this.users.Add(users_element);
			}
		}

		public override string ToString()
		{
			return String.Format("(messageActionChatCreate title:'{0}' users:{1})", title, Serializers.VectorToString(users));
		}
	}


	public class MessageActionChatEditTitleConstructor : MessageAction
	{
		public string title;

		public MessageActionChatEditTitleConstructor()
		{

		}

		public MessageActionChatEditTitleConstructor(string title)
		{
			this.title = title;
		}


		public Constructor Constructor
		{
			get { return Constructor.messageActionChatEditTitle; }
		}

		public override void Write(BinaryWriter writer)
		{
			writer.Write(0xb5a1ce5a);
			Serializers.String.write(writer, this.title);
		}

		public override void Read(BinaryReader reader)
		{
			this.title = Serializers.String.read(reader);
		}

		public override string ToString()
		{
			return String.Format("(messageActionChatEditTitle title:'{0}')", title);
		}
	}


	public class MessageActionChatEditPhotoConstructor : MessageAction
	{
		public Photo photo;

		public MessageActionChatEditPhotoConstructor()
		{

		}

		public MessageActionChatEditPhotoConstructor(Photo photo)
		{
			this.photo = photo;
		}


		public Constructor Constructor
		{
			get { return Constructor.messageActionChatEditPhoto; }
		}

		public override void Write(BinaryWriter writer)
		{
			writer.Write(0x7fcb13a8);
			this.photo.Write(writer);
		}

		public override void Read(BinaryReader reader)
		{
			this.photo = TL.Parse<Photo>(reader);
		}

		public override string ToString()
		{
			return String.Format("(messageActionChatEditPhoto photo:{0})", photo);
		}
	}


	public class MessageActionChatDeletePhotoConstructor : MessageAction
	{

		public MessageActionChatDeletePhotoConstructor()
		{

		}



		public Constructor Constructor
		{
			get { return Constructor.messageActionChatDeletePhoto; }
		}

		public override void Write(BinaryWriter writer)
		{
			writer.Write(0x95e3fbef);
		}

		public override void Read(BinaryReader reader)
		{
		}

		public override string ToString()
		{
			return String.Format("(messageActionChatDeletePhoto)");
		}
	}


	public class MessageActionChatAddUserConstructor : MessageAction
	{
		public int user_id;

		public MessageActionChatAddUserConstructor()
		{

		}

		public MessageActionChatAddUserConstructor(int user_id)
		{
			this.user_id = user_id;
		}


		public Constructor Constructor
		{
			get { return Constructor.messageActionChatAddUser; }
		}

		public override void Write(BinaryWriter writer)
		{
			writer.Write(0x5e3cfc4b);
			writer.Write(this.user_id);
		}

		public override void Read(BinaryReader reader)
		{
			this.user_id = reader.ReadInt32();
		}

		public override string ToString()
		{
			return String.Format("(messageActionChatAddUser user_id:{0})", user_id);
		}
	}


	public class MessageActionChatDeleteUserConstructor : MessageAction
	{
		public int user_id;

		public MessageActionChatDeleteUserConstructor()
		{

		}

		public MessageActionChatDeleteUserConstructor(int user_id)
		{
			this.user_id = user_id;
		}


		public Constructor Constructor
		{
			get { return Constructor.messageActionChatDeleteUser; }
		}

		public override void Write(BinaryWriter writer)
		{
			writer.Write(0xb2ae9b0c);
			writer.Write(this.user_id);
		}

		public override void Read(BinaryReader reader)
		{
			this.user_id = reader.ReadInt32();
		}

		public override string ToString()
		{
			return String.Format("(messageActionChatDeleteUser user_id:{0})", user_id);
		}
	}


	public class DialogConstructor : Dialog
	{
		public Peer peer;
		public int top_message;
		public int unread_count;

		public DialogConstructor()
		{

		}

		public DialogConstructor(Peer peer, int top_message, int unread_count)
		{
			this.peer = peer;
			this.top_message = top_message;
			this.unread_count = unread_count;
		}


		public Constructor Constructor
		{
			get { return Constructor.dialog; }
		}

		public override void Write(BinaryWriter writer)
		{
			writer.Write(0x214a8cdf);
			this.peer.Write(writer);
			writer.Write(this.top_message);
			writer.Write(this.unread_count);
		}

		public override void Read(BinaryReader reader)
		{
			this.peer = TL.Parse<Peer>(reader);
			this.top_message = reader.ReadInt32();
			this.unread_count = reader.ReadInt32();
		}

		public override string ToString()
		{
			return String.Format("(dialog peer:{0} top_message:{1} unread_count:{2})", peer, top_message, unread_count);
		}
	}


	public class PhotoEmptyConstructor : Photo
	{
		public long id;

		public PhotoEmptyConstructor()
		{

		}

		public PhotoEmptyConstructor(long id)
		{
			this.id = id;
		}


		public Constructor Constructor
		{
			get { return Constructor.photoEmpty; }
		}

		public override void Write(BinaryWriter writer)
		{
			writer.Write(0x2331b22d);
			writer.Write(this.id);
		}

		public override void Read(BinaryReader reader)
		{
			this.id = reader.ReadInt64();
		}

		public override string ToString()
		{
			return String.Format("(photoEmpty id:{0})", id);
		}
	}


	public class PhotoConstructor : Photo
	{
		public long id;
		public long access_hash;
		public int user_id;
		public int date;
		public string caption;
		public GeoPoint geo;
		public List<PhotoSize> sizes;

		public PhotoConstructor()
		{

		}

		public PhotoConstructor(long id, long access_hash, int user_id, int date, string caption, GeoPoint geo,
			List<PhotoSize> sizes)
		{
			this.id = id;
			this.access_hash = access_hash;
			this.user_id = user_id;
			this.date = date;
			this.caption = caption;
			this.geo = geo;
			this.sizes = sizes;
		}


		public Constructor Constructor
		{
			get { return Constructor.photo; }
		}

		public override void Write(BinaryWriter writer)
		{
			writer.Write(0x22b56751);
			writer.Write(this.id);
			writer.Write(this.access_hash);
			writer.Write(this.user_id);
			writer.Write(this.date);
			Serializers.String.write(writer, this.caption);
			this.geo.Write(writer);
			writer.Write(0x1cb5c415);
			writer.Write(this.sizes.Count);
			foreach (PhotoSize sizes_element in this.sizes)
			{
				sizes_element.Write(writer);
			}
		}

		public override void Read(BinaryReader reader)
		{
			this.id = reader.ReadInt64();
			this.access_hash = reader.ReadInt64();
			this.user_id = reader.ReadInt32();
			this.date = reader.ReadInt32();
			this.caption = Serializers.String.read(reader);
			this.geo = TL.Parse<GeoPoint>(reader);
			reader.ReadInt32(); // vector code
			int sizes_len = reader.ReadInt32();
			this.sizes = new List<PhotoSize>(sizes_len);
			for (int sizes_index = 0; sizes_index < sizes_len; sizes_index++)
			{
				PhotoSize sizes_element;
				sizes_element = TL.Parse<PhotoSize>(reader);
				this.sizes.Add(sizes_element);
			}
		}

		public override string ToString()
		{
			return String.Format("(photo id:{0} access_hash:{1} user_id:{2} date:{3} caption:'{4}' geo:{5} sizes:{6})", id,
				access_hash, user_id, date, caption, geo, Serializers.VectorToString(sizes));
		}
	}


	public class PhotoSizeEmptyConstructor : PhotoSize
	{
		public string type;

		public PhotoSizeEmptyConstructor()
		{

		}

		public PhotoSizeEmptyConstructor(string type)
		{
			this.type = type;
		}


		public Constructor Constructor
		{
			get { return Constructor.photoSizeEmpty; }
		}

		public override void Write(BinaryWriter writer)
		{
			writer.Write(0x0e17e23c);
			Serializers.String.write(writer, this.type);
		}

		public override void Read(BinaryReader reader)
		{
			this.type = Serializers.String.read(reader);
		}

		public override string ToString()
		{
			return String.Format("(photoSizeEmpty type:'{0}')", type);
		}
	}


	public class PhotoSizeConstructor : PhotoSize
	{
		public string type;
		public FileLocation location;
		public int w;
		public int h;
		public int size;

		public PhotoSizeConstructor()
		{

		}

		public PhotoSizeConstructor(string type, FileLocation location, int w, int h, int size)
		{
			this.type = type;
			this.location = location;
			this.w = w;
			this.h = h;
			this.size = size;
		}


		public Constructor Constructor
		{
			get { return Constructor.photoSize; }
		}

		public override void Write(BinaryWriter writer)
		{
			writer.Write(0x77bfb61b);
			Serializers.String.write(writer, this.type);
			this.location.Write(writer);
			writer.Write(this.w);
			writer.Write(this.h);
			writer.Write(this.size);
		}

		public override void Read(BinaryReader reader)
		{
			this.type = Serializers.String.read(reader);
			this.location = TL.Parse<FileLocation>(reader);
			this.w = reader.ReadInt32();
			this.h = reader.ReadInt32();
			this.size = reader.ReadInt32();
		}

		public override string ToString()
		{
			return String.Format("(photoSize type:'{0}' location:{1} w:{2} h:{3} size:{4})", type, location, w, h, size);
		}
	}


	public class PhotoCachedSizeConstructor : PhotoSize
	{
		public string type;
		public FileLocation location;
		public int w;
		public int h;
		public byte[] bytes;

		public PhotoCachedSizeConstructor()
		{

		}

		public PhotoCachedSizeConstructor(string type, FileLocation location, int w, int h, byte[] bytes)
		{
			this.type = type;
			this.location = location;
			this.w = w;
			this.h = h;
			this.bytes = bytes;
		}


		public Constructor Constructor
		{
			get { return Constructor.photoCachedSize; }
		}

		public override void Write(BinaryWriter writer)
		{
			writer.Write(0xe9a734fa);
			Serializers.String.write(writer, this.type);
			this.location.Write(writer);
			writer.Write(this.w);
			writer.Write(this.h);
			Serializers.Bytes.write(writer, this.bytes);
		}

		public override void Read(BinaryReader reader)
		{
			this.type = Serializers.String.read(reader);
			this.location = TL.Parse<FileLocation>(reader);
			this.w = reader.ReadInt32();
			this.h = reader.ReadInt32();
			this.bytes = Serializers.Bytes.read(reader);
		}

		public override string ToString()
		{
			return String.Format("(photoCachedSize type:'{0}' location:{1} w:{2} h:{3} bytes:{4})", type, location, w, h,
				BitConverter.ToString(bytes));
		}
	}


	public class VideoEmptyConstructor : Video
	{
		public long id;

		public VideoEmptyConstructor()
		{

		}

		public VideoEmptyConstructor(long id)
		{
			this.id = id;
		}


		public Constructor Constructor
		{
			get { return Constructor.videoEmpty; }
		}

		public override void Write(BinaryWriter writer)
		{
			writer.Write(0xc10658a8);
			writer.Write(this.id);
		}

		public override void Read(BinaryReader reader)
		{
			this.id = reader.ReadInt64();
		}

		public override string ToString()
		{
			return String.Format("(videoEmpty id:{0})", id);
		}
	}


	public class VideoConstructor : Video
	{
		public long id;
		public long access_hash;
		public int user_id;
		public int date;
		public string caption;
		public int duration;
		public int size;
		public PhotoSize thumb;
		public int dc_id;
		public int w;
		public int h;

		public VideoConstructor()
		{

		}

		public VideoConstructor(long id, long access_hash, int user_id, int date, string caption, int duration, int size,
			PhotoSize thumb, int dc_id, int w, int h)
		{
			this.id = id;
			this.access_hash = access_hash;
			this.user_id = user_id;
			this.date = date;
			this.caption = caption;
			this.duration = duration;
			this.size = size;
			this.thumb = thumb;
			this.dc_id = dc_id;
			this.w = w;
			this.h = h;
		}


		public Constructor Constructor
		{
			get { return Constructor.video; }
		}

		public override void Write(BinaryWriter writer)
		{
			writer.Write(0x5a04a49f);
			writer.Write(this.id);
			writer.Write(this.access_hash);
			writer.Write(this.user_id);
			writer.Write(this.date);
			Serializers.String.write(writer, this.caption);
			writer.Write(this.duration);
			writer.Write(this.size);
			this.thumb.Write(writer);
			writer.Write(this.dc_id);
			writer.Write(this.w);
			writer.Write(this.h);
		}

		public override void Read(BinaryReader reader)
		{
			this.id = reader.ReadInt64();
			this.access_hash = reader.ReadInt64();
			this.user_id = reader.ReadInt32();
			this.date = reader.ReadInt32();
			this.caption = Serializers.String.read(reader);
			this.duration = reader.ReadInt32();
			this.size = reader.ReadInt32();
			this.thumb = TL.Parse<PhotoSize>(reader);
			this.dc_id = reader.ReadInt32();
			this.w = reader.ReadInt32();
			this.h = reader.ReadInt32();
		}

		public override string ToString()
		{
			return
				String.Format(
					"(video id:{0} access_hash:{1} user_id:{2} date:{3} caption:'{4}' duration:{5} size:{6} thumb:{7} dc_id:{8} w:{9} h:{10})",
					id, access_hash, user_id, date, caption, duration, size, thumb, dc_id, w, h);
		}
	}


	public class GeoPointEmptyConstructor : GeoPoint
	{

		public GeoPointEmptyConstructor()
		{

		}



		public Constructor Constructor
		{
			get { return Constructor.geoPointEmpty; }
		}

		public override void Write(BinaryWriter writer)
		{
			writer.Write(0x1117dd5f);
		}

		public override void Read(BinaryReader reader)
		{
		}

		public override string ToString()
		{
			return String.Format("(geoPointEmpty)");
		}
	}


	public class GeoPointConstructor : GeoPoint
	{
		public double lng;
		public double lat;

		public GeoPointConstructor()
		{

		}

		public GeoPointConstructor(double lng, double lat)
		{
			this.lng = lng;
			this.lat = lat;
		}


		public Constructor Constructor
		{
			get { return Constructor.geoPoint; }
		}

		public override void Write(BinaryWriter writer)
		{
			writer.Write(0x2049d70c);
			writer.Write(this.lng);
			writer.Write(this.lat);
		}

		public override void Read(BinaryReader reader)
		{
			this.lng = reader.ReadDouble();
			this.lat = reader.ReadDouble();
		}

		public override string ToString()
		{
			return String.Format("(geoPoint long:{0} lat:{1})", lng, lat);
		}
	}


	public class Auth_checkedPhoneConstructor : auth_CheckedPhone
	{
		public bool phone_registered;
		public bool phone_invited;

		public Auth_checkedPhoneConstructor()
		{

		}

		public Auth_checkedPhoneConstructor(bool phone_registered, bool phone_invited)
		{
			this.phone_registered = phone_registered;
			this.phone_invited = phone_invited;
		}


		public Constructor Constructor
		{
			get { return Constructor.auth_checkedPhone; }
		}

		public override void Write(BinaryWriter writer)
		{
			writer.Write(0xe300cc3b);
			writer.Write(this.phone_registered ? 0x997275b5 : 0xbc799737);
			writer.Write(this.phone_invited ? 0x997275b5 : 0xbc799737);
		}

		public override void Read(BinaryReader reader)
		{
			this.phone_registered = reader.ReadUInt32() == 0x997275b5;
			this.phone_invited = reader.ReadUInt32() == 0x997275b5;
		}

		public override string ToString()
		{
			return String.Format("(auth_checkedPhone phone_registered:{0} phone_invited:{1})", phone_registered, phone_invited);
		}
	}


	public class Auth_sentCodeConstructor : auth_SentCode
	{
		public bool phone_registered;
		public string phone_code_hash;

		public Auth_sentCodeConstructor()
		{

		}

		public Auth_sentCodeConstructor(bool phone_registered, string phone_code_hash)
		{
			this.phone_registered = phone_registered;
			this.phone_code_hash = phone_code_hash;
		}


		public Constructor Constructor
		{
			get { return Constructor.auth_sentCode; }
		}

		public override void Write(BinaryWriter writer)
		{
			writer.Write(0x2215bcbd);
			writer.Write(this.phone_registered ? 0x997275b5 : 0xbc799737);
			Serializers.String.write(writer, this.phone_code_hash);
		}

		public override void Read(BinaryReader reader)
		{
			this.phone_registered = reader.ReadUInt32() == 0x997275b5;
			this.phone_code_hash = Serializers.String.read(reader);
		}

		public override string ToString()
		{
			return String.Format("(auth_sentCode phone_registered:{0} phone_code_hash:'{1}')", phone_registered, phone_code_hash);
		}
	}


	public class Auth_authorizationConstructor : auth_Authorization
	{
		public int expires;
		public User user;

		public Auth_authorizationConstructor()
		{

		}

		public Auth_authorizationConstructor(int expires, User user)
		{
			this.expires = expires;
			this.user = user;
		}


		public Constructor Constructor
		{
			get { return Constructor.auth_authorization; }
		}

		public override void Write(BinaryWriter writer)
		{
			writer.Write(0xf6b673a4);
			writer.Write(this.expires);
			this.user.Write(writer);
		}

		public override void Read(BinaryReader reader)
		{
			this.expires = reader.ReadInt32();
			this.user = TL.Parse<User>(reader);
		}

		public override string ToString()
		{
			return String.Format("(auth_authorization expires:{0} user:{1})", expires, user);
		}
	}


	public class Auth_exportedAuthorizationConstructor : auth_ExportedAuthorization
	{
		public int id;
		public byte[] bytes;

		public Auth_exportedAuthorizationConstructor()
		{

		}

		public Auth_exportedAuthorizationConstructor(int id, byte[] bytes)
		{
			this.id = id;
			this.bytes = bytes;
		}


		public Constructor Constructor
		{
			get { return Constructor.auth_exportedAuthorization; }
		}

		public override void Write(BinaryWriter writer)
		{
			writer.Write(0xdf969c2d);
			writer.Write(this.id);
			Serializers.Bytes.write(writer, this.bytes);
		}

		public override void Read(BinaryReader reader)
		{
			this.id = reader.ReadInt32();
			this.bytes = Serializers.Bytes.read(reader);
		}

		public override string ToString()
		{
			return String.Format("(auth_exportedAuthorization id:{0} bytes:{1})", id, BitConverter.ToString(bytes));
		}
	}


	public class InputNotifyPeerConstructor : InputNotifyPeer
	{
		public InputPeer peer;

		public InputNotifyPeerConstructor()
		{

		}

		public InputNotifyPeerConstructor(InputPeer peer)
		{
			this.peer = peer;
		}


		public Constructor Constructor
		{
			get { return Constructor.inputNotifyPeer; }
		}

		public override void Write(BinaryWriter writer)
		{
			writer.Write(0xb8bc5b0c);
			this.peer.Write(writer);
		}

		public override void Read(BinaryReader reader)
		{
			this.peer = TL.Parse<InputPeer>(reader);
		}

		public override string ToString()
		{
			return String.Format("(inputNotifyPeer peer:{0})", peer);
		}
	}


	public class InputNotifyUsersConstructor : InputNotifyPeer
	{

		public InputNotifyUsersConstructor()
		{

		}



		public Constructor Constructor
		{
			get { return Constructor.inputNotifyUsers; }
		}

		public override void Write(BinaryWriter writer)
		{
			writer.Write(0x193b4417);
		}

		public override void Read(BinaryReader reader)
		{
		}

		public override string ToString()
		{
			return String.Format("(inputNotifyUsers)");
		}
	}


	public class InputNotifyChatsConstructor : InputNotifyPeer
	{

		public InputNotifyChatsConstructor()
		{

		}



		public Constructor Constructor
		{
			get { return Constructor.inputNotifyChats; }
		}

		public override void Write(BinaryWriter writer)
		{
			writer.Write(0x4a95e84e);
		}

		public override void Read(BinaryReader reader)
		{
		}

		public override string ToString()
		{
			return String.Format("(inputNotifyChats)");
		}
	}


	public class InputNotifyAllConstructor : InputNotifyPeer
	{

		public InputNotifyAllConstructor()
		{

		}



		public Constructor Constructor
		{
			get { return Constructor.inputNotifyAll; }
		}

		public override void Write(BinaryWriter writer)
		{
			writer.Write(0xa429b886);
		}

		public override void Read(BinaryReader reader)
		{
		}

		public override string ToString()
		{
			return String.Format("(inputNotifyAll)");
		}
	}


	public class InputPeerNotifyEventsEmptyConstructor : InputPeerNotifyEvents
	{

		public InputPeerNotifyEventsEmptyConstructor()
		{

		}



		public Constructor Constructor
		{
			get { return Constructor.inputPeerNotifyEventsEmpty; }
		}

		public override void Write(BinaryWriter writer)
		{
			writer.Write(0xf03064d8);
		}

		public override void Read(BinaryReader reader)
		{
		}

		public override string ToString()
		{
			return String.Format("(inputPeerNotifyEventsEmpty)");
		}
	}


	public class InputPeerNotifyEventsAllConstructor : InputPeerNotifyEvents
	{

		public InputPeerNotifyEventsAllConstructor()
		{

		}



		public Constructor Constructor
		{
			get { return Constructor.inputPeerNotifyEventsAll; }
		}

		public override void Write(BinaryWriter writer)
		{
			writer.Write(0xe86a2c74);
		}

		public override void Read(BinaryReader reader)
		{
		}

		public override string ToString()
		{
			return String.Format("(inputPeerNotifyEventsAll)");
		}
	}


	public class InputPeerNotifySettingsConstructor : InputPeerNotifySettings
	{
		public int mute_until;
		public string sound;
		public bool show_previews;
		public int events_mask;

		public InputPeerNotifySettingsConstructor()
		{

		}

		public InputPeerNotifySettingsConstructor(int mute_until, string sound, bool show_previews, int events_mask)
		{
			this.mute_until = mute_until;
			this.sound = sound;
			this.show_previews = show_previews;
			this.events_mask = events_mask;
		}


		public Constructor Constructor
		{
			get { return Constructor.inputPeerNotifySettings; }
		}

		public override void Write(BinaryWriter writer)
		{
			writer.Write(0x46a2ce98);
			writer.Write(this.mute_until);
			Serializers.String.write(writer, this.sound);
			writer.Write(this.show_previews ? 0x997275b5 : 0xbc799737);
			writer.Write(this.events_mask);
		}

		public override void Read(BinaryReader reader)
		{
			this.mute_until = reader.ReadInt32();
			this.sound = Serializers.String.read(reader);
			this.show_previews = reader.ReadUInt32() == 0x997275b5;
			this.events_mask = reader.ReadInt32();
		}

		public override string ToString()
		{
			return String.Format("(inputPeerNotifySettings mute_until:{0} sound:'{1}' show_previews:{2} events_mask:{3})",
				mute_until, sound, show_previews, events_mask);
		}
	}


	public class PeerNotifyEventsEmptyConstructor : PeerNotifyEvents
	{

		public PeerNotifyEventsEmptyConstructor()
		{

		}



		public Constructor Constructor
		{
			get { return Constructor.peerNotifyEventsEmpty; }
		}

		public override void Write(BinaryWriter writer)
		{
			writer.Write(0xadd53cb3);
		}

		public override void Read(BinaryReader reader)
		{
		}

		public override string ToString()
		{
			return String.Format("(peerNotifyEventsEmpty)");
		}
	}


	public class PeerNotifyEventsAllConstructor : PeerNotifyEvents
	{

		public PeerNotifyEventsAllConstructor()
		{

		}



		public Constructor Constructor
		{
			get { return Constructor.peerNotifyEventsAll; }
		}

		public override void Write(BinaryWriter writer)
		{
			writer.Write(0x6d1ded88);
		}

		public override void Read(BinaryReader reader)
		{
		}

		public override string ToString()
		{
			return String.Format("(peerNotifyEventsAll)");
		}
	}


	public class PeerNotifySettingsEmptyConstructor : PeerNotifySettings
	{

		public PeerNotifySettingsEmptyConstructor()
		{

		}



		public Constructor Constructor
		{
			get { return Constructor.peerNotifySettingsEmpty; }
		}

		public override void Write(BinaryWriter writer)
		{
			writer.Write(0x70a68512);
		}

		public override void Read(BinaryReader reader)
		{
		}

		public override string ToString()
		{
			return String.Format("(peerNotifySettingsEmpty)");
		}
	}


	public class PeerNotifySettingsConstructor : PeerNotifySettings
	{
		public int mute_until;
		public string sound;
		public bool show_previews;
		public int events_mask;

		public PeerNotifySettingsConstructor()
		{

		}

		public PeerNotifySettingsConstructor(int mute_until, string sound, bool show_previews, int events_mask)
		{
			this.mute_until = mute_until;
			this.sound = sound;
			this.show_previews = show_previews;
			this.events_mask = events_mask;
		}


		public Constructor Constructor
		{
			get { return Constructor.peerNotifySettings; }
		}

		public override void Write(BinaryWriter writer)
		{
			writer.Write(0x8d5e11ee);
			writer.Write(this.mute_until);
			Serializers.String.write(writer, this.sound);
			writer.Write(this.show_previews ? 0x997275b5 : 0xbc799737);
			writer.Write(this.events_mask);
		}

		public override void Read(BinaryReader reader)
		{
			this.mute_until = reader.ReadInt32();
			this.sound = Serializers.String.read(reader);
			this.show_previews = reader.ReadUInt32() == 0x997275b5;
			this.events_mask = reader.ReadInt32();
		}

		public override string ToString()
		{
			return String.Format("(peerNotifySettings mute_until:{0} sound:'{1}' show_previews:{2} events_mask:{3})", mute_until,
				sound, show_previews, events_mask);
		}
	}


	public class WallPaperConstructor : WallPaper
	{
		public int id;
		public string title;
		public List<PhotoSize> sizes;
		public int color;

		public WallPaperConstructor()
		{

		}

		public WallPaperConstructor(int id, string title, List<PhotoSize> sizes, int color)
		{
			this.id = id;
			this.title = title;
			this.sizes = sizes;
			this.color = color;
		}


		public Constructor Constructor
		{
			get { return Constructor.wallPaper; }
		}

		public override void Write(BinaryWriter writer)
		{
			writer.Write(0xccb03657);
			writer.Write(this.id);
			Serializers.String.write(writer, this.title);
			writer.Write(0x1cb5c415);
			writer.Write(this.sizes.Count);
			foreach (PhotoSize sizes_element in this.sizes)
			{
				sizes_element.Write(writer);
			}
			writer.Write(this.color);
		}

		public override void Read(BinaryReader reader)
		{
			this.id = reader.ReadInt32();
			this.title = Serializers.String.read(reader);
			reader.ReadInt32(); // vector code
			int sizes_len = reader.ReadInt32();
			this.sizes = new List<PhotoSize>(sizes_len);
			for (int sizes_index = 0; sizes_index < sizes_len; sizes_index++)
			{
				PhotoSize sizes_element;
				sizes_element = TL.Parse<PhotoSize>(reader);
				this.sizes.Add(sizes_element);
			}
			this.color = reader.ReadInt32();
		}

		public override string ToString()
		{
			return String.Format("(wallPaper id:{0} title:'{1}' sizes:{2} color:{3})", id, title,
				Serializers.VectorToString(sizes), color);
		}
	}


	public class UserFullConstructor : UserFull
	{
		public User user;
		public contacts_Link link;
		public Photo profile_photo;
		public PeerNotifySettings notify_settings;
		public bool blocked;
		public string real_first_name;
		public string real_last_name;

		public UserFullConstructor()
		{

		}

		public UserFullConstructor(User user, contacts_Link link, Photo profile_photo, PeerNotifySettings notify_settings,
			bool blocked, string real_first_name, string real_last_name)
		{
			this.user = user;
			this.link = link;
			this.profile_photo = profile_photo;
			this.notify_settings = notify_settings;
			this.blocked = blocked;
			this.real_first_name = real_first_name;
			this.real_last_name = real_last_name;
		}


		public Constructor Constructor
		{
			get { return Constructor.userFull; }
		}

		public override void Write(BinaryWriter writer)
		{
			writer.Write(0x771095da);
			this.user.Write(writer);
			this.link.Write(writer);
			this.profile_photo.Write(writer);
			this.notify_settings.Write(writer);
			writer.Write(this.blocked ? 0x997275b5 : 0xbc799737);
			Serializers.String.write(writer, this.real_first_name);
			Serializers.String.write(writer, this.real_last_name);
		}

		public override void Read(BinaryReader reader)
		{
			this.user = TL.Parse<User>(reader);
			this.link = TL.Parse<contacts_Link>(reader);
			this.profile_photo = TL.Parse<Photo>(reader);
			this.notify_settings = TL.Parse<PeerNotifySettings>(reader);
			this.blocked = reader.ReadUInt32() == 0x997275b5;
			this.real_first_name = Serializers.String.read(reader);
			this.real_last_name = Serializers.String.read(reader);
		}

		public override string ToString()
		{
			return
				String.Format(
					"(userFull user:{0} link:{1} profile_photo:{2} notify_settings:{3} blocked:{4} real_first_name:'{5}' real_last_name:'{6}')",
					user, link, profile_photo, notify_settings, blocked, real_first_name, real_last_name);
		}
	}


	public class ContactConstructor : Contact
	{
		public int user_id;
		public bool mutual;

		public ContactConstructor()
		{

		}

		public ContactConstructor(int user_id, bool mutual)
		{
			this.user_id = user_id;
			this.mutual = mutual;
		}


		public Constructor Constructor
		{
			get { return Constructor.contact; }
		}

		public override void Write(BinaryWriter writer)
		{
			writer.Write(0xf911c994);
			writer.Write(this.user_id);
			writer.Write(this.mutual ? 0x997275b5 : 0xbc799737);
		}

		public override void Read(BinaryReader reader)
		{
			this.user_id = reader.ReadInt32();
			this.mutual = reader.ReadUInt32() == 0x997275b5;
		}

		public override string ToString()
		{
			return String.Format("(contact user_id:{0} mutual:{1})", user_id, mutual);
		}
	}


	public class ImportedContactConstructor : ImportedContact
	{
		public int user_id;
		public long client_id;

		public ImportedContactConstructor()
		{

		}

		public ImportedContactConstructor(int user_id, long client_id)
		{
			this.user_id = user_id;
			this.client_id = client_id;
		}


		public Constructor Constructor
		{
			get { return Constructor.importedContact; }
		}

		public override void Write(BinaryWriter writer)
		{
			writer.Write(0xd0028438);
			writer.Write(this.user_id);
			writer.Write(this.client_id);
		}

		public override void Read(BinaryReader reader)
		{
			this.user_id = reader.ReadInt32();
			this.client_id = reader.ReadInt64();
		}

		public override string ToString()
		{
			return String.Format("(importedContact user_id:{0} client_id:{1})", user_id, client_id);
		}
	}


	public class ContactBlockedConstructor : ContactBlocked
	{
		public int user_id;
		public int date;

		public ContactBlockedConstructor()
		{

		}

		public ContactBlockedConstructor(int user_id, int date)
		{
			this.user_id = user_id;
			this.date = date;
		}


		public Constructor Constructor
		{
			get { return Constructor.contactBlocked; }
		}

		public override void Write(BinaryWriter writer)
		{
			writer.Write(0x561bc879);
			writer.Write(this.user_id);
			writer.Write(this.date);
		}

		public override void Read(BinaryReader reader)
		{
			this.user_id = reader.ReadInt32();
			this.date = reader.ReadInt32();
		}

		public override string ToString()
		{
			return String.Format("(contactBlocked user_id:{0} date:{1})", user_id, date);
		}
	}


	public class ContactFoundConstructor : ContactFound
	{
		public int user_id;

		public ContactFoundConstructor()
		{

		}

		public ContactFoundConstructor(int user_id)
		{
			this.user_id = user_id;
		}


		public Constructor Constructor
		{
			get { return Constructor.contactFound; }
		}

		public override void Write(BinaryWriter writer)
		{
			writer.Write(0xea879f95);
			writer.Write(this.user_id);
		}

		public override void Read(BinaryReader reader)
		{
			this.user_id = reader.ReadInt32();
		}

		public override string ToString()
		{
			return String.Format("(contactFound user_id:{0})", user_id);
		}
	}


	public class ContactSuggestedConstructor : ContactSuggested
	{
		public int user_id;
		public int mutual_contacts;

		public ContactSuggestedConstructor()
		{

		}

		public ContactSuggestedConstructor(int user_id, int mutual_contacts)
		{
			this.user_id = user_id;
			this.mutual_contacts = mutual_contacts;
		}


		public Constructor Constructor
		{
			get { return Constructor.contactSuggested; }
		}

		public override void Write(BinaryWriter writer)
		{
			writer.Write(0x3de191a1);
			writer.Write(this.user_id);
			writer.Write(this.mutual_contacts);
		}

		public override void Read(BinaryReader reader)
		{
			this.user_id = reader.ReadInt32();
			this.mutual_contacts = reader.ReadInt32();
		}

		public override string ToString()
		{
			return String.Format("(contactSuggested user_id:{0} mutual_contacts:{1})", user_id, mutual_contacts);
		}
	}


	public class ContactStatusConstructor : ContactStatus
	{
		public int user_id;
		public int expires;

		public ContactStatusConstructor()
		{

		}

		public ContactStatusConstructor(int user_id, int expires)
		{
			this.user_id = user_id;
			this.expires = expires;
		}


		public Constructor Constructor
		{
			get { return Constructor.contactStatus; }
		}

		public override void Write(BinaryWriter writer)
		{
			writer.Write(0xaa77b873);
			writer.Write(this.user_id);
			writer.Write(this.expires);
		}

		public override void Read(BinaryReader reader)
		{
			this.user_id = reader.ReadInt32();
			this.expires = reader.ReadInt32();
		}

		public override string ToString()
		{
			return String.Format("(contactStatus user_id:{0} expires:{1})", user_id, expires);
		}
	}


	public class ChatLocatedConstructor : ChatLocated
	{
		public int chat_id;
		public int distance;

		public ChatLocatedConstructor()
		{

		}

		public ChatLocatedConstructor(int chat_id, int distance)
		{
			this.chat_id = chat_id;
			this.distance = distance;
		}


		public Constructor Constructor
		{
			get { return Constructor.chatLocated; }
		}

		public override void Write(BinaryWriter writer)
		{
			writer.Write(0x3631cf4c);
			writer.Write(this.chat_id);
			writer.Write(this.distance);
		}

		public override void Read(BinaryReader reader)
		{
			this.chat_id = reader.ReadInt32();
			this.distance = reader.ReadInt32();
		}

		public override string ToString()
		{
			return String.Format("(chatLocated chat_id:{0} distance:{1})", chat_id, distance);
		}
	}


	public class Contacts_foreignLinkUnknownConstructor : contacts_ForeignLink
	{

		public Contacts_foreignLinkUnknownConstructor()
		{

		}



		public Constructor Constructor
		{
			get { return Constructor.contacts_foreignLinkUnknown; }
		}

		public override void Write(BinaryWriter writer)
		{
			writer.Write(0x133421f8);
		}

		public override void Read(BinaryReader reader)
		{
		}

		public override string ToString()
		{
			return String.Format("(contacts_foreignLinkUnknown)");
		}
	}


	public class Contacts_foreignLinkRequestedConstructor : contacts_ForeignLink
	{
		public bool has_phone;

		public Contacts_foreignLinkRequestedConstructor()
		{

		}

		public Contacts_foreignLinkRequestedConstructor(bool has_phone)
		{
			this.has_phone = has_phone;
		}


		public Constructor Constructor
		{
			get { return Constructor.contacts_foreignLinkRequested; }
		}

		public override void Write(BinaryWriter writer)
		{
			writer.Write(0xa7801f47);
			writer.Write(this.has_phone ? 0x997275b5 : 0xbc799737);
		}

		public override void Read(BinaryReader reader)
		{
			this.has_phone = reader.ReadUInt32() == 0x997275b5;
		}

		public override string ToString()
		{
			return String.Format("(contacts_foreignLinkRequested has_phone:{0})", has_phone);
		}
	}


	public class Contacts_foreignLinkMutualConstructor : contacts_ForeignLink
	{

		public Contacts_foreignLinkMutualConstructor()
		{

		}



		public Constructor Constructor
		{
			get { return Constructor.contacts_foreignLinkMutual; }
		}

		public override void Write(BinaryWriter writer)
		{
			writer.Write(0x1bea8ce1);
		}

		public override void Read(BinaryReader reader)
		{
		}

		public override string ToString()
		{
			return String.Format("(contacts_foreignLinkMutual)");
		}
	}


	public class Contacts_myLinkEmptyConstructor : contacts_MyLink
	{

		public Contacts_myLinkEmptyConstructor()
		{

		}



		public Constructor Constructor
		{
			get { return Constructor.contacts_myLinkEmpty; }
		}

		public override void Write(BinaryWriter writer)
		{
			writer.Write(0xd22a1c60);
		}

		public override void Read(BinaryReader reader)
		{
		}

		public override string ToString()
		{
			return String.Format("(contacts_myLinkEmpty)");
		}
	}


	public class Contacts_myLinkRequestedConstructor : contacts_MyLink
	{
		public bool contact;

		public Contacts_myLinkRequestedConstructor()
		{

		}

		public Contacts_myLinkRequestedConstructor(bool contact)
		{
			this.contact = contact;
		}


		public Constructor Constructor
		{
			get { return Constructor.contacts_myLinkRequested; }
		}

		public override void Write(BinaryWriter writer)
		{
			writer.Write(0x6c69efee);
			writer.Write(this.contact ? 0x997275b5 : 0xbc799737);
		}

		public override void Read(BinaryReader reader)
		{
			this.contact = reader.ReadUInt32() == 0x997275b5;
		}

		public override string ToString()
		{
			return String.Format("(contacts_myLinkRequested contact:{0})", contact);
		}
	}


	public class Contacts_myLinkContactConstructor : contacts_MyLink
	{

		public Contacts_myLinkContactConstructor()
		{

		}



		public Constructor Constructor
		{
			get { return Constructor.contacts_myLinkContact; }
		}

		public override void Write(BinaryWriter writer)
		{
			writer.Write(0xc240ebd9);
		}

		public override void Read(BinaryReader reader)
		{
		}

		public override string ToString()
		{
			return String.Format("(contacts_myLinkContact)");
		}
	}


	public class Contacts_linkConstructor : contacts_Link
	{
		public contacts_MyLink my_link;
		public contacts_ForeignLink foreign_link;
		public User user;

		public Contacts_linkConstructor()
		{

		}

		public Contacts_linkConstructor(contacts_MyLink my_link, contacts_ForeignLink foreign_link, User user)
		{
			this.my_link = my_link;
			this.foreign_link = foreign_link;
			this.user = user;
		}


		public Constructor Constructor
		{
			get { return Constructor.contacts_link; }
		}

		public override void Write(BinaryWriter writer)
		{
			writer.Write(0xeccea3f5);
			this.my_link.Write(writer);
			this.foreign_link.Write(writer);
			this.user.Write(writer);
		}

		public override void Read(BinaryReader reader)
		{
			this.my_link = TL.Parse<contacts_MyLink>(reader);
			this.foreign_link = TL.Parse<contacts_ForeignLink>(reader);
			this.user = TL.Parse<User>(reader);
		}

		public override string ToString()
		{
			return String.Format("(contacts_link my_link:{0} foreign_link:{1} user:{2})", my_link, foreign_link, user);
		}
	}


	public class Contacts_contactsConstructor : contacts_Contacts
	{
		public List<Contact> contacts;
		public List<User> users;

		public Contacts_contactsConstructor()
		{

		}

		public Contacts_contactsConstructor(List<Contact> contacts, List<User> users)
		{
			this.contacts = contacts;
			this.users = users;
		}


		public Constructor Constructor
		{
			get { return Constructor.contacts_contacts; }
		}

		public override void Write(BinaryWriter writer)
		{
			writer.Write(0x6f8b8cb2);
			writer.Write(0x1cb5c415);
			writer.Write(this.contacts.Count);
			foreach (Contact contacts_element in this.contacts)
			{
				contacts_element.Write(writer);
			}
			writer.Write(0x1cb5c415);
			writer.Write(this.users.Count);
			foreach (User users_element in this.users)
			{
				users_element.Write(writer);
			}
		}

		public override void Read(BinaryReader reader)
		{
			reader.ReadInt32(); // vector code
			int contacts_len = reader.ReadInt32();
			this.contacts = new List<Contact>(contacts_len);
			for (int contacts_index = 0; contacts_index < contacts_len; contacts_index++)
			{
				Contact contacts_element;
				contacts_element = TL.Parse<Contact>(reader);
				this.contacts.Add(contacts_element);
			}
			reader.ReadInt32(); // vector code
			int users_len = reader.ReadInt32();
			this.users = new List<User>(users_len);
			for (int users_index = 0; users_index < users_len; users_index++)
			{
				User users_element;
				users_element = TL.Parse<User>(reader);
				this.users.Add(users_element);
			}
		}

		public override string ToString()
		{
			return String.Format("(contacts_contacts contacts:{0} users:{1})", Serializers.VectorToString(contacts),
				Serializers.VectorToString(users));
		}
	}


	public class Contacts_contactsNotModifiedConstructor : contacts_Contacts
	{

		public Contacts_contactsNotModifiedConstructor()
		{

		}



		public Constructor Constructor
		{
			get { return Constructor.contacts_contactsNotModified; }
		}

		public override void Write(BinaryWriter writer)
		{
			writer.Write(0xb74ba9d2);
		}

		public override void Read(BinaryReader reader)
		{
		}

		public override string ToString()
		{
			return String.Format("(contacts_contactsNotModified)");
		}
	}


	public class Contacts_importedContactsConstructor : contacts_ImportedContacts
	{
		public List<ImportedContact> imported;
		public List<User> users;

		public Contacts_importedContactsConstructor()
		{

		}

		public Contacts_importedContactsConstructor(List<ImportedContact> imported, List<User> users)
		{
			this.imported = imported;
			this.users = users;
		}


		public Constructor Constructor
		{
			get { return Constructor.contacts_importedContacts; }
		}

		public override void Write(BinaryWriter writer)
		{
			writer.Write(0xd1cd0a4c);
			writer.Write(0x1cb5c415);
			writer.Write(this.imported.Count);
			foreach (ImportedContact imported_element in this.imported)
			{
				imported_element.Write(writer);
			}
			writer.Write(0x1cb5c415);
			writer.Write(this.users.Count);
			foreach (User users_element in this.users)
			{
				users_element.Write(writer);
			}
		}

		public override void Read(BinaryReader reader)
		{
			reader.ReadInt32(); // vector code
			int imported_len = reader.ReadInt32();
			this.imported = new List<ImportedContact>(imported_len);
			for (int imported_index = 0; imported_index < imported_len; imported_index++)
			{
				ImportedContact imported_element;
				imported_element = TL.Parse<ImportedContact>(reader);
				this.imported.Add(imported_element);
			}
			reader.ReadInt32(); // vector code
			int users_len = reader.ReadInt32();
			this.users = new List<User>(users_len);
			for (int users_index = 0; users_index < users_len; users_index++)
			{
				User users_element;
				users_element = TL.Parse<User>(reader);
				this.users.Add(users_element);
			}
		}

		public override string ToString()
		{
			return String.Format("(contacts_importedContacts imported:{0} users:{1})", Serializers.VectorToString(imported),
				Serializers.VectorToString(users));
		}
	}


	public class Contacts_blockedConstructor : contacts_Blocked
	{
		public List<ContactBlocked> blocked;
		public List<User> users;

		public Contacts_blockedConstructor()
		{

		}

		public Contacts_blockedConstructor(List<ContactBlocked> blocked, List<User> users)
		{
			this.blocked = blocked;
			this.users = users;
		}


		public Constructor Constructor
		{
			get { return Constructor.contacts_blocked; }
		}

		public override void Write(BinaryWriter writer)
		{
			writer.Write(0x1c138d15);
			writer.Write(0x1cb5c415);
			writer.Write(this.blocked.Count);
			foreach (ContactBlocked blocked_element in this.blocked)
			{
				blocked_element.Write(writer);
			}
			writer.Write(0x1cb5c415);
			writer.Write(this.users.Count);
			foreach (User users_element in this.users)
			{
				users_element.Write(writer);
			}
		}

		public override void Read(BinaryReader reader)
		{
			reader.ReadInt32(); // vector code
			int blocked_len = reader.ReadInt32();
			this.blocked = new List<ContactBlocked>(blocked_len);
			for (int blocked_index = 0; blocked_index < blocked_len; blocked_index++)
			{
				ContactBlocked blocked_element;
				blocked_element = TL.Parse<ContactBlocked>(reader);
				this.blocked.Add(blocked_element);
			}
			reader.ReadInt32(); // vector code
			int users_len = reader.ReadInt32();
			this.users = new List<User>(users_len);
			for (int users_index = 0; users_index < users_len; users_index++)
			{
				User users_element;
				users_element = TL.Parse<User>(reader);
				this.users.Add(users_element);
			}
		}

		public override string ToString()
		{
			return String.Format("(contacts_blocked blocked:{0} users:{1})", Serializers.VectorToString(blocked),
				Serializers.VectorToString(users));
		}
	}


	public class Contacts_blockedSliceConstructor : contacts_Blocked
	{
		public int count;
		public List<ContactBlocked> blocked;
		public List<User> users;

		public Contacts_blockedSliceConstructor()
		{

		}

		public Contacts_blockedSliceConstructor(int count, List<ContactBlocked> blocked, List<User> users)
		{
			this.count = count;
			this.blocked = blocked;
			this.users = users;
		}


		public Constructor Constructor
		{
			get { return Constructor.contacts_blockedSlice; }
		}

		public override void Write(BinaryWriter writer)
		{
			writer.Write(0x900802a1);
			writer.Write(this.count);
			writer.Write(0x1cb5c415);
			writer.Write(this.blocked.Count);
			foreach (ContactBlocked blocked_element in this.blocked)
			{
				blocked_element.Write(writer);
			}
			writer.Write(0x1cb5c415);
			writer.Write(this.users.Count);
			foreach (User users_element in this.users)
			{
				users_element.Write(writer);
			}
		}

		public override void Read(BinaryReader reader)
		{
			this.count = reader.ReadInt32();
			reader.ReadInt32(); // vector code
			int blocked_len = reader.ReadInt32();
			this.blocked = new List<ContactBlocked>(blocked_len);
			for (int blocked_index = 0; blocked_index < blocked_len; blocked_index++)
			{
				ContactBlocked blocked_element;
				blocked_element = TL.Parse<ContactBlocked>(reader);
				this.blocked.Add(blocked_element);
			}
			reader.ReadInt32(); // vector code
			int users_len = reader.ReadInt32();
			this.users = new List<User>(users_len);
			for (int users_index = 0; users_index < users_len; users_index++)
			{
				User users_element;
				users_element = TL.Parse<User>(reader);
				this.users.Add(users_element);
			}
		}

		public override string ToString()
		{
			return String.Format("(contacts_blockedSlice count:{0} blocked:{1} users:{2})", count,
				Serializers.VectorToString(blocked), Serializers.VectorToString(users));
		}
	}


	public class Contacts_foundConstructor : contacts_Found
	{
		public List<ContactFound> results;
		public List<User> users;

		public Contacts_foundConstructor()
		{

		}

		public Contacts_foundConstructor(List<ContactFound> results, List<User> users)
		{
			this.results = results;
			this.users = users;
		}


		public Constructor Constructor
		{
			get { return Constructor.contacts_found; }
		}

		public override void Write(BinaryWriter writer)
		{
			writer.Write(0x0566000e);
			writer.Write(0x1cb5c415);
			writer.Write(this.results.Count);
			foreach (ContactFound results_element in this.results)
			{
				results_element.Write(writer);
			}
			writer.Write(0x1cb5c415);
			writer.Write(this.users.Count);
			foreach (User users_element in this.users)
			{
				users_element.Write(writer);
			}
		}

		public override void Read(BinaryReader reader)
		{
			reader.ReadInt32(); // vector code
			int results_len = reader.ReadInt32();
			this.results = new List<ContactFound>(results_len);
			for (int results_index = 0; results_index < results_len; results_index++)
			{
				ContactFound results_element;
				results_element = TL.Parse<ContactFound>(reader);
				this.results.Add(results_element);
			}
			reader.ReadInt32(); // vector code
			int users_len = reader.ReadInt32();
			this.users = new List<User>(users_len);
			for (int users_index = 0; users_index < users_len; users_index++)
			{
				User users_element;
				users_element = TL.Parse<User>(reader);
				this.users.Add(users_element);
			}
		}

		public override string ToString()
		{
			return String.Format("(contacts_found results:{0} users:{1})", Serializers.VectorToString(results),
				Serializers.VectorToString(users));
		}
	}


	public class Contacts_suggestedConstructor : contacts_Suggested
	{
		public List<ContactSuggested> results;
		public List<User> users;

		public Contacts_suggestedConstructor()
		{

		}

		public Contacts_suggestedConstructor(List<ContactSuggested> results, List<User> users)
		{
			this.results = results;
			this.users = users;
		}


		public Constructor Constructor
		{
			get { return Constructor.contacts_suggested; }
		}

		public override void Write(BinaryWriter writer)
		{
			writer.Write(0x5649dcc5);
			writer.Write(0x1cb5c415);
			writer.Write(this.results.Count);
			foreach (ContactSuggested results_element in this.results)
			{
				results_element.Write(writer);
			}
			writer.Write(0x1cb5c415);
			writer.Write(this.users.Count);
			foreach (User users_element in this.users)
			{
				users_element.Write(writer);
			}
		}

		public override void Read(BinaryReader reader)
		{
			reader.ReadInt32(); // vector code
			int results_len = reader.ReadInt32();
			this.results = new List<ContactSuggested>(results_len);
			for (int results_index = 0; results_index < results_len; results_index++)
			{
				ContactSuggested results_element;
				results_element = TL.Parse<ContactSuggested>(reader);
				this.results.Add(results_element);
			}
			reader.ReadInt32(); // vector code
			int users_len = reader.ReadInt32();
			this.users = new List<User>(users_len);
			for (int users_index = 0; users_index < users_len; users_index++)
			{
				User users_element;
				users_element = TL.Parse<User>(reader);
				this.users.Add(users_element);
			}
		}

		public override string ToString()
		{
			return String.Format("(contacts_suggested results:{0} users:{1})", Serializers.VectorToString(results),
				Serializers.VectorToString(users));
		}
	}


	public class Messages_dialogsConstructor : messages_Dialogs
	{
		public List<Dialog> dialogs;
		public List<Message> messages;
		public List<Chat> chats;
		public List<User> users;

		public Messages_dialogsConstructor()
		{

		}

		public Messages_dialogsConstructor(List<Dialog> dialogs, List<Message> messages, List<Chat> chats, List<User> users)
		{
			this.dialogs = dialogs;
			this.messages = messages;
			this.chats = chats;
			this.users = users;
		}


		public Constructor Constructor
		{
			get { return Constructor.messages_dialogs; }
		}

		public override void Write(BinaryWriter writer)
		{
			writer.Write(0x15ba6c40);
			writer.Write(0x1cb5c415);
			writer.Write(this.dialogs.Count);
			foreach (Dialog dialogs_element in this.dialogs)
			{
				dialogs_element.Write(writer);
			}
			writer.Write(0x1cb5c415);
			writer.Write(this.messages.Count);
			foreach (Message messages_element in this.messages)
			{
				messages_element.Write(writer);
			}
			writer.Write(0x1cb5c415);
			writer.Write(this.chats.Count);
			foreach (Chat chats_element in this.chats)
			{
				chats_element.Write(writer);
			}
			writer.Write(0x1cb5c415);
			writer.Write(this.users.Count);
			foreach (User users_element in this.users)
			{
				users_element.Write(writer);
			}
		}

		public override void Read(BinaryReader reader)
		{
			reader.ReadInt32(); // vector code
			int dialogs_len = reader.ReadInt32();
			this.dialogs = new List<Dialog>(dialogs_len);
			for (int dialogs_index = 0; dialogs_index < dialogs_len; dialogs_index++)
			{
				Dialog dialogs_element;
				dialogs_element = TL.Parse<Dialog>(reader);
				this.dialogs.Add(dialogs_element);
			}
			reader.ReadInt32(); // vector code
			int messages_len = reader.ReadInt32();
			this.messages = new List<Message>(messages_len);
			for (int messages_index = 0; messages_index < messages_len; messages_index++)
			{
				Message messages_element;
				messages_element = TL.Parse<Message>(reader);
				this.messages.Add(messages_element);
			}
			reader.ReadInt32(); // vector code
			int chats_len = reader.ReadInt32();
			this.chats = new List<Chat>(chats_len);
			for (int chats_index = 0; chats_index < chats_len; chats_index++)
			{
				Chat chats_element;
				chats_element = TL.Parse<Chat>(reader);
				this.chats.Add(chats_element);
			}
			reader.ReadInt32(); // vector code
			int users_len = reader.ReadInt32();
			this.users = new List<User>(users_len);
			for (int users_index = 0; users_index < users_len; users_index++)
			{
				User users_element;
				users_element = TL.Parse<User>(reader);
				this.users.Add(users_element);
			}
		}

		public override string ToString()
		{
			return String.Format("(messages_dialogs dialogs:{0} messages:{1} chats:{2} users:{3})",
				Serializers.VectorToString(dialogs), Serializers.VectorToString(messages), Serializers.VectorToString(chats),
				Serializers.VectorToString(users));
		}
	}


	public class Messages_dialogsSliceConstructor : messages_Dialogs
	{
		public int count;
		public List<Dialog> dialogs;
		public List<Message> messages;
		public List<Chat> chats;
		public List<User> users;

		public Messages_dialogsSliceConstructor()
		{

		}

		public Messages_dialogsSliceConstructor(int count, List<Dialog> dialogs, List<Message> messages, List<Chat> chats,
			List<User> users)
		{
			this.count = count;
			this.dialogs = dialogs;
			this.messages = messages;
			this.chats = chats;
			this.users = users;
		}


		public Constructor Constructor
		{
			get { return Constructor.messages_dialogsSlice; }
		}

		public override void Write(BinaryWriter writer)
		{
			writer.Write(0x71e094f3);
			writer.Write(this.count);
			writer.Write(0x1cb5c415);
			writer.Write(this.dialogs.Count);
			foreach (Dialog dialogs_element in this.dialogs)
			{
				dialogs_element.Write(writer);
			}
			writer.Write(0x1cb5c415);
			writer.Write(this.messages.Count);
			foreach (Message messages_element in this.messages)
			{
				messages_element.Write(writer);
			}
			writer.Write(0x1cb5c415);
			writer.Write(this.chats.Count);
			foreach (Chat chats_element in this.chats)
			{
				chats_element.Write(writer);
			}
			writer.Write(0x1cb5c415);
			writer.Write(this.users.Count);
			foreach (User users_element in this.users)
			{
				users_element.Write(writer);
			}
		}

		public override void Read(BinaryReader reader)
		{
			this.count = reader.ReadInt32();
			reader.ReadInt32(); // vector code
			int dialogs_len = reader.ReadInt32();
			this.dialogs = new List<Dialog>(dialogs_len);
			for (int dialogs_index = 0; dialogs_index < dialogs_len; dialogs_index++)
			{
				Dialog dialogs_element;
				dialogs_element = TL.Parse<Dialog>(reader);
				this.dialogs.Add(dialogs_element);
			}
			reader.ReadInt32(); // vector code
			int messages_len = reader.ReadInt32();
			this.messages = new List<Message>(messages_len);
			for (int messages_index = 0; messages_index < messages_len; messages_index++)
			{
				Message messages_element;
				messages_element = TL.Parse<Message>(reader);
				this.messages.Add(messages_element);
			}
			reader.ReadInt32(); // vector code
			int chats_len = reader.ReadInt32();
			this.chats = new List<Chat>(chats_len);
			for (int chats_index = 0; chats_index < chats_len; chats_index++)
			{
				Chat chats_element;
				chats_element = TL.Parse<Chat>(reader);
				this.chats.Add(chats_element);
			}
			reader.ReadInt32(); // vector code
			int users_len = reader.ReadInt32();
			this.users = new List<User>(users_len);
			for (int users_index = 0; users_index < users_len; users_index++)
			{
				User users_element;
				users_element = TL.Parse<User>(reader);
				this.users.Add(users_element);
			}
		}

		public override string ToString()
		{
			return String.Format("(messages_dialogsSlice count:{0} dialogs:{1} messages:{2} chats:{3} users:{4})", count,
				Serializers.VectorToString(dialogs), Serializers.VectorToString(messages), Serializers.VectorToString(chats),
				Serializers.VectorToString(users));
		}
	}


	public class Messages_messagesConstructor : messages_Messages
	{
		public List<Message> messages;
		public List<Chat> chats;
		public List<User> users;

		public Messages_messagesConstructor()
		{

		}

		public Messages_messagesConstructor(List<Message> messages, List<Chat> chats, List<User> users)
		{
			this.messages = messages;
			this.chats = chats;
			this.users = users;
		}


		public Constructor Constructor
		{
			get { return Constructor.messages_messages; }
		}

		public override void Write(BinaryWriter writer)
		{
			writer.Write(0x8c718e87);
			writer.Write(0x1cb5c415);
			writer.Write(this.messages.Count);
			foreach (Message messages_element in this.messages)
			{
				messages_element.Write(writer);
			}
			writer.Write(0x1cb5c415);
			writer.Write(this.chats.Count);
			foreach (Chat chats_element in this.chats)
			{
				chats_element.Write(writer);
			}
			writer.Write(0x1cb5c415);
			writer.Write(this.users.Count);
			foreach (User users_element in this.users)
			{
				users_element.Write(writer);
			}
		}

		public override void Read(BinaryReader reader)
		{
			reader.ReadInt32(); // vector code
			int messages_len = reader.ReadInt32();
			this.messages = new List<Message>(messages_len);
			for (int messages_index = 0; messages_index < messages_len; messages_index++)
			{
				Message messages_element;
				messages_element = TL.Parse<Message>(reader);
				this.messages.Add(messages_element);
			}
			reader.ReadInt32(); // vector code
			int chats_len = reader.ReadInt32();
			this.chats = new List<Chat>(chats_len);
			for (int chats_index = 0; chats_index < chats_len; chats_index++)
			{
				Chat chats_element;
				chats_element = TL.Parse<Chat>(reader);
				this.chats.Add(chats_element);
			}
			reader.ReadInt32(); // vector code
			int users_len = reader.ReadInt32();
			this.users = new List<User>(users_len);
			for (int users_index = 0; users_index < users_len; users_index++)
			{
				User users_element;
				users_element = TL.Parse<User>(reader);
				this.users.Add(users_element);
			}
		}

		public override string ToString()
		{
			return String.Format("(messages_messages messages:{0} chats:{1} users:{2})", Serializers.VectorToString(messages),
				Serializers.VectorToString(chats), Serializers.VectorToString(users));
		}
	}


	public class Messages_messagesSliceConstructor : messages_Messages
	{
		public int count;
		public List<Message> messages;
		public List<Chat> chats;
		public List<User> users;

		public Messages_messagesSliceConstructor()
		{

		}

		public Messages_messagesSliceConstructor(int count, List<Message> messages, List<Chat> chats, List<User> users)
		{
			this.count = count;
			this.messages = messages;
			this.chats = chats;
			this.users = users;
		}


		public Constructor Constructor
		{
			get { return Constructor.messages_messagesSlice; }
		}

		public override void Write(BinaryWriter writer)
		{
			writer.Write(0x0b446ae3);
			writer.Write(this.count);
			writer.Write(0x1cb5c415);
			writer.Write(this.messages.Count);
			foreach (Message messages_element in this.messages)
			{
				messages_element.Write(writer);
			}
			writer.Write(0x1cb5c415);
			writer.Write(this.chats.Count);
			foreach (Chat chats_element in this.chats)
			{
				chats_element.Write(writer);
			}
			writer.Write(0x1cb5c415);
			writer.Write(this.users.Count);
			foreach (User users_element in this.users)
			{
				users_element.Write(writer);
			}
		}

		public override void Read(BinaryReader reader)
		{
			this.count = reader.ReadInt32();
			reader.ReadInt32(); // vector code
			int messages_len = reader.ReadInt32();
			this.messages = new List<Message>(messages_len);
			for (int messages_index = 0; messages_index < messages_len; messages_index++)
			{
				Message messages_element;
				messages_element = TL.Parse<Message>(reader);
				this.messages.Add(messages_element);
			}
			reader.ReadInt32(); // vector code
			int chats_len = reader.ReadInt32();
			this.chats = new List<Chat>(chats_len);
			for (int chats_index = 0; chats_index < chats_len; chats_index++)
			{
				Chat chats_element;
				chats_element = TL.Parse<Chat>(reader);
				this.chats.Add(chats_element);
			}
			reader.ReadInt32(); // vector code
			int users_len = reader.ReadInt32();
			this.users = new List<User>(users_len);
			for (int users_index = 0; users_index < users_len; users_index++)
			{
				User users_element;
				users_element = TL.Parse<User>(reader);
				this.users.Add(users_element);
			}
		}

		public override string ToString()
		{
			return String.Format("(messages_messagesSlice count:{0} messages:{1} chats:{2} users:{3})", count,
				Serializers.VectorToString(messages), Serializers.VectorToString(chats), Serializers.VectorToString(users));
		}
	}


	public class Messages_messageEmptyConstructor : messages_Message
	{

		public Messages_messageEmptyConstructor()
		{

		}



		public Constructor Constructor
		{
			get { return Constructor.messages_messageEmpty; }
		}

		public override void Write(BinaryWriter writer)
		{
			writer.Write(0x3f4e0648);
		}

		public override void Read(BinaryReader reader)
		{
		}

		public override string ToString()
		{
			return String.Format("(messages_messageEmpty)");
		}
	}


	public class Messages_messageConstructor : messages_Message
	{
		public Message message;
		public List<Chat> chats;
		public List<User> users;

		public Messages_messageConstructor()
		{

		}

		public Messages_messageConstructor(Message message, List<Chat> chats, List<User> users)
		{
			this.message = message;
			this.chats = chats;
			this.users = users;
		}


		public Constructor Constructor
		{
			get { return Constructor.messages_message; }
		}

		public override void Write(BinaryWriter writer)
		{
			writer.Write(0xff90c417);
			this.message.Write(writer);
			writer.Write(0x1cb5c415);
			writer.Write(this.chats.Count);
			foreach (Chat chats_element in this.chats)
			{
				chats_element.Write(writer);
			}
			writer.Write(0x1cb5c415);
			writer.Write(this.users.Count);
			foreach (User users_element in this.users)
			{
				users_element.Write(writer);
			}
		}

		public override void Read(BinaryReader reader)
		{
			this.message = TL.Parse<Message>(reader);
			reader.ReadInt32(); // vector code
			int chats_len = reader.ReadInt32();
			this.chats = new List<Chat>(chats_len);
			for (int chats_index = 0; chats_index < chats_len; chats_index++)
			{
				Chat chats_element;
				chats_element = TL.Parse<Chat>(reader);
				this.chats.Add(chats_element);
			}
			reader.ReadInt32(); // vector code
			int users_len = reader.ReadInt32();
			this.users = new List<User>(users_len);
			for (int users_index = 0; users_index < users_len; users_index++)
			{
				User users_element;
				users_element = TL.Parse<User>(reader);
				this.users.Add(users_element);
			}
		}

		public override string ToString()
		{
			return String.Format("(messages_message message:{0} chats:{1} users:{2})", message, Serializers.VectorToString(chats),
				Serializers.VectorToString(users));
		}
	}


	public class Messages_statedMessagesConstructor : messages_StatedMessages
	{
		public List<Message> messages;
		public List<Chat> chats;
		public List<User> users;
		public int pts;
		public int seq;

		public Messages_statedMessagesConstructor()
		{

		}

		public Messages_statedMessagesConstructor(List<Message> messages, List<Chat> chats, List<User> users, int pts, int seq)
		{
			this.messages = messages;
			this.chats = chats;
			this.users = users;
			this.pts = pts;
			this.seq = seq;
		}


		public Constructor Constructor
		{
			get { return Constructor.messages_statedMessages; }
		}

		public override void Write(BinaryWriter writer)
		{
			writer.Write(0x969478bb);
			writer.Write(0x1cb5c415);
			writer.Write(this.messages.Count);
			foreach (Message messages_element in this.messages)
			{
				messages_element.Write(writer);
			}
			writer.Write(0x1cb5c415);
			writer.Write(this.chats.Count);
			foreach (Chat chats_element in this.chats)
			{
				chats_element.Write(writer);
			}
			writer.Write(0x1cb5c415);
			writer.Write(this.users.Count);
			foreach (User users_element in this.users)
			{
				users_element.Write(writer);
			}
			writer.Write(this.pts);
			writer.Write(this.seq);
		}

		public override void Read(BinaryReader reader)
		{
			reader.ReadInt32(); // vector code
			int messages_len = reader.ReadInt32();
			this.messages = new List<Message>(messages_len);
			for (int messages_index = 0; messages_index < messages_len; messages_index++)
			{
				Message messages_element;
				messages_element = TL.Parse<Message>(reader);
				this.messages.Add(messages_element);
			}
			reader.ReadInt32(); // vector code
			int chats_len = reader.ReadInt32();
			this.chats = new List<Chat>(chats_len);
			for (int chats_index = 0; chats_index < chats_len; chats_index++)
			{
				Chat chats_element;
				chats_element = TL.Parse<Chat>(reader);
				this.chats.Add(chats_element);
			}
			reader.ReadInt32(); // vector code
			int users_len = reader.ReadInt32();
			this.users = new List<User>(users_len);
			for (int users_index = 0; users_index < users_len; users_index++)
			{
				User users_element;
				users_element = TL.Parse<User>(reader);
				this.users.Add(users_element);
			}
			this.pts = reader.ReadInt32();
			this.seq = reader.ReadInt32();
		}

		public override string ToString()
		{
			return String.Format("(messages_statedMessages messages:{0} chats:{1} users:{2} pts:{3} seq:{4})",
				Serializers.VectorToString(messages), Serializers.VectorToString(chats), Serializers.VectorToString(users), pts, seq);
		}
	}


	public class Messages_statedMessageConstructor : messages_StatedMessage
	{
		public Message message;
		public List<Chat> chats;
		public List<User> users;
		public int pts;
		public int seq;

		public Messages_statedMessageConstructor()
		{

		}

		public Messages_statedMessageConstructor(Message message, List<Chat> chats, List<User> users, int pts, int seq)
		{
			this.message = message;
			this.chats = chats;
			this.users = users;
			this.pts = pts;
			this.seq = seq;
		}


		public Constructor Constructor
		{
			get { return Constructor.messages_statedMessage; }
		}

		public override void Write(BinaryWriter writer)
		{
			writer.Write(0xd07ae726);
			this.message.Write(writer);
			writer.Write(0x1cb5c415);
			writer.Write(this.chats.Count);
			foreach (Chat chats_element in this.chats)
			{
				chats_element.Write(writer);
			}
			writer.Write(0x1cb5c415);
			writer.Write(this.users.Count);
			foreach (User users_element in this.users)
			{
				users_element.Write(writer);
			}
			writer.Write(this.pts);
			writer.Write(this.seq);
		}

		public override void Read(BinaryReader reader)
		{
			this.message = TL.Parse<Message>(reader);
			reader.ReadInt32(); // vector code
			int chats_len = reader.ReadInt32();
			this.chats = new List<Chat>(chats_len);
			for (int chats_index = 0; chats_index < chats_len; chats_index++)
			{
				Chat chats_element;
				chats_element = TL.Parse<Chat>(reader);
				this.chats.Add(chats_element);
			}
			/*
			reader.ReadInt32(); // vector code
			int users_len = reader.ReadInt32();
			this.users = new List<User>(users_len);
			for (int users_index = 0; users_index < users_len; users_index++)
			{
				User users_element;
				users_element = TL.Parse<User>(reader);
				this.users.Add(users_element);
			}
			this.pts = reader.ReadInt32();
			this.seq = reader.ReadInt32();
			*/
        }

        public override string ToString()
		{
			return String.Format("(messages_statedMessage message:{0} chats:{1} users:{2} pts:{3} seq:{4})", message,
				Serializers.VectorToString(chats), Serializers.VectorToString(users), pts, seq);
		}
	}


	public class Messages_sentMessageConstructor : messages_SentMessage
	{
		public int id;
		public int date;
		public int pts;
		public int seq;

		public Messages_sentMessageConstructor()
		{

		}

		public Messages_sentMessageConstructor(int id, int date, int pts, int seq)
		{
			this.id = id;
			this.date = date;
			this.pts = pts;
			this.seq = seq;
		}


		public Constructor Constructor
		{
			get { return Constructor.messages_sentMessage; }
		}

		public override void Write(BinaryWriter writer)
		{
			writer.Write(0xd1f4d35c);
			writer.Write(this.id);
			writer.Write(this.date);
			writer.Write(this.pts);
			writer.Write(this.seq);
		}

		public override void Read(BinaryReader reader)
		{
			this.id = reader.ReadInt32();
			this.date = reader.ReadInt32();
			this.pts = reader.ReadInt32();
			this.seq = reader.ReadInt32();
		}

		public override string ToString()
		{
			return String.Format("(messages_sentMessage id:{0} date:{1} pts:{2} seq:{3})", id, date, pts, seq);
		}
	}


	public class Messages_chatConstructor : messages_Chat
	{
		public Chat chat;
		public List<User> users;

		public Messages_chatConstructor()
		{

		}

		public Messages_chatConstructor(Chat chat, List<User> users)
		{
			this.chat = chat;
			this.users = users;
		}


		public Constructor Constructor
		{
			get { return Constructor.messages_chat; }
		}

		public override void Write(BinaryWriter writer)
		{
			writer.Write(0x40e9002a);
			this.chat.Write(writer);
			writer.Write(0x1cb5c415);
			writer.Write(this.users.Count);
			foreach (User users_element in this.users)
			{
				users_element.Write(writer);
			}
		}

		public override void Read(BinaryReader reader)
		{
			this.chat = TL.Parse<Chat>(reader);
			reader.ReadInt32(); // vector code
			int users_len = reader.ReadInt32();
			this.users = new List<User>(users_len);
			for (int users_index = 0; users_index < users_len; users_index++)
			{
				User users_element;
				users_element = TL.Parse<User>(reader);
				this.users.Add(users_element);
			}
		}

		public override string ToString()
		{
			return String.Format("(messages_chat chat:{0} users:{1})", chat, Serializers.VectorToString(users));
		}
	}


	public class Messages_chatsConstructor : messages_Chats
	{
		public List<Chat> chats;
		public List<User> users;

		public Messages_chatsConstructor()
		{

		}

		public Messages_chatsConstructor(List<Chat> chats, List<User> users)
		{
			this.chats = chats;
			this.users = users;
		}


		public Constructor Constructor
		{
			get { return Constructor.messages_chats; }
		}

		public override void Write(BinaryWriter writer)
		{
			writer.Write(0x8150cbd8);
			writer.Write(0x1cb5c415);
			writer.Write(this.chats.Count);
			foreach (Chat chats_element in this.chats)
			{
				chats_element.Write(writer);
			}
			writer.Write(0x1cb5c415);
			writer.Write(this.users.Count);
			foreach (User users_element in this.users)
			{
				users_element.Write(writer);
			}
		}

		public override void Read(BinaryReader reader)
		{
			reader.ReadInt32(); // vector code
			int chats_len = reader.ReadInt32();
			this.chats = new List<Chat>(chats_len);
			for (int chats_index = 0; chats_index < chats_len; chats_index++)
			{
				Chat chats_element;
				chats_element = TL.Parse<Chat>(reader);
				this.chats.Add(chats_element);
			}
			reader.ReadInt32(); // vector code
			int users_len = reader.ReadInt32();
			this.users = new List<User>(users_len);
			for (int users_index = 0; users_index < users_len; users_index++)
			{
				User users_element;
				users_element = TL.Parse<User>(reader);
				this.users.Add(users_element);
			}
		}

		public override string ToString()
		{
			return String.Format("(messages_chats chats:{0} users:{1})", Serializers.VectorToString(chats),
				Serializers.VectorToString(users));
		}
	}


	public class Messages_chatFullConstructor : messages_ChatFull
	{
		public ChatFull full_chat;
		public List<Chat> chats;
		public List<User> users;

		public Messages_chatFullConstructor()
		{

		}

		public Messages_chatFullConstructor(ChatFull full_chat, List<Chat> chats, List<User> users)
		{
			this.full_chat = full_chat;
			this.chats = chats;
			this.users = users;
		}


		public Constructor Constructor
		{
			get { return Constructor.messages_chatFull; }
		}

		public override void Write(BinaryWriter writer)
		{
			writer.Write(0xe5d7d19c);
			this.full_chat.Write(writer);
			writer.Write(0x1cb5c415);
			writer.Write(this.chats.Count);
			foreach (Chat chats_element in this.chats)
			{
				chats_element.Write(writer);
			}
			writer.Write(0x1cb5c415);
			writer.Write(this.users.Count);
			foreach (User users_element in this.users)
			{
				users_element.Write(writer);
			}
		}

		public override void Read(BinaryReader reader)
		{
			this.full_chat = TL.Parse<ChatFull>(reader);
			reader.ReadInt32(); // vector code
			int chats_len = reader.ReadInt32();
			this.chats = new List<Chat>(chats_len);
			for (int chats_index = 0; chats_index < chats_len; chats_index++)
			{
				Chat chats_element;
				chats_element = TL.Parse<Chat>(reader);
				this.chats.Add(chats_element);
			}
			reader.ReadInt32(); // vector code
			int users_len = reader.ReadInt32();
			this.users = new List<User>(users_len);
			for (int users_index = 0; users_index < users_len; users_index++)
			{
				User users_element;
				users_element = TL.Parse<User>(reader);
				this.users.Add(users_element);
			}
		}

		public override string ToString()
		{
			return String.Format("(messages_chatFull full_chat:{0} chats:{1} users:{2})", full_chat,
				Serializers.VectorToString(chats), Serializers.VectorToString(users));
		}
	}


	public class Messages_affectedHistoryConstructor : messages_AffectedHistory
	{
		public int pts;
		public int seq;
		public int offset;

		public Messages_affectedHistoryConstructor()
		{

		}

		public Messages_affectedHistoryConstructor(int pts, int seq, int offset)
		{
			this.pts = pts;
			this.seq = seq;
			this.offset = offset;
		}


		public Constructor Constructor
		{
			get { return Constructor.messages_affectedHistory; }
		}

		public override void Write(BinaryWriter writer)
		{
			writer.Write(0xb7de36f2);
			writer.Write(this.pts);
			writer.Write(this.seq);
			writer.Write(this.offset);
		}

		public override void Read(BinaryReader reader)
		{
			this.pts = reader.ReadInt32();
			this.seq = reader.ReadInt32();
			this.offset = reader.ReadInt32();
		}

		public override string ToString()
		{
			return String.Format("(messages_affectedHistory pts:{0} seq:{1} offset:{2})", pts, seq, offset);
		}
	}


	public class InputMessagesFilterEmptyConstructor : MessagesFilter
	{

		public InputMessagesFilterEmptyConstructor()
		{

		}



		public Constructor Constructor
		{
			get { return Constructor.inputMessagesFilterEmpty; }
		}

		public override void Write(BinaryWriter writer)
		{
			writer.Write(0x57e2f66c);
		}

		public override void Read(BinaryReader reader)
		{
		}

		public override string ToString()
		{
			return String.Format("(inputMessagesFilterEmpty)");
		}
	}


	public class InputMessagesFilterPhotosConstructor : MessagesFilter
	{

		public InputMessagesFilterPhotosConstructor()
		{

		}



		public Constructor Constructor
		{
			get { return Constructor.inputMessagesFilterPhotos; }
		}

		public override void Write(BinaryWriter writer)
		{
			writer.Write(0x9609a51c);
		}

		public override void Read(BinaryReader reader)
		{
		}

		public override string ToString()
		{
			return String.Format("(inputMessagesFilterPhotos)");
		}
	}


	public class InputMessagesFilterVideoConstructor : MessagesFilter
	{

		public InputMessagesFilterVideoConstructor()
		{

		}



		public Constructor Constructor
		{
			get { return Constructor.inputMessagesFilterVideo; }
		}

		public override void Write(BinaryWriter writer)
		{
			writer.Write(0x9fc00e65);
		}

		public override void Read(BinaryReader reader)
		{
		}

		public override string ToString()
		{
			return String.Format("(inputMessagesFilterVideo)");
		}
	}


	public class InputMessagesFilterPhotoVideoConstructor : MessagesFilter
	{

		public InputMessagesFilterPhotoVideoConstructor()
		{

		}



		public Constructor Constructor
		{
			get { return Constructor.inputMessagesFilterPhotoVideo; }
		}

		public override void Write(BinaryWriter writer)
		{
			writer.Write(0x56e9f0e4);
		}

		public override void Read(BinaryReader reader)
		{
		}

		public override string ToString()
		{
			return String.Format("(inputMessagesFilterPhotoVideo)");
		}
	}


	public class UpdateNewMessageConstructor : Update
	{
		public Message message;
		public int pts;

		public UpdateNewMessageConstructor()
		{

		}

		public UpdateNewMessageConstructor(Message message, int pts)
		{
			this.message = message;
			this.pts = pts;
		}


		public Constructor Constructor
		{
			get { return Constructor.updateNewMessage; }
		}

		public override void Write(BinaryWriter writer)
		{
			writer.Write(0x013abdb3);
			this.message.Write(writer);
			writer.Write(this.pts);
		}

		public override void Read(BinaryReader reader)
		{
			this.message = TL.Parse<Message>(reader);
			this.pts = reader.ReadInt32();
		}

		public override string ToString()
		{
			return String.Format("(updateNewMessage message:{0} pts:{1})", message, pts);
		}
	}


	public class UpdateMessageIDConstructor : Update
	{
		public int id;
		public long random_id;

		public UpdateMessageIDConstructor()
		{

		}

		public UpdateMessageIDConstructor(int id, long random_id)
		{
			this.id = id;
			this.random_id = random_id;
		}


		public Constructor Constructor
		{
			get { return Constructor.updateMessageID; }
		}

		public override void Write(BinaryWriter writer)
		{
			writer.Write(0x4e90bfd6);
			writer.Write(this.id);
			writer.Write(this.random_id);
		}

		public override void Read(BinaryReader reader)
		{
			this.id = reader.ReadInt32();
			this.random_id = reader.ReadInt64();
		}

		public override string ToString()
		{
			return String.Format("(updateMessageID id:{0} random_id:{1})", id, random_id);
		}
	}


	public class UpdateReadMessagesConstructor : Update
	{
		public List<int> messages;
		public int pts;

		public UpdateReadMessagesConstructor()
		{

		}

		public UpdateReadMessagesConstructor(List<int> messages, int pts)
		{
			this.messages = messages;
			this.pts = pts;
		}


		public Constructor Constructor
		{
			get { return Constructor.updateReadMessages; }
		}

		public override void Write(BinaryWriter writer)
		{
			writer.Write(0xc6649e31);
			writer.Write(0x1cb5c415);
			writer.Write(this.messages.Count);
			foreach (int messages_element in this.messages)
			{
				writer.Write(messages_element);
			}
			writer.Write(this.pts);
		}

		public override void Read(BinaryReader reader)
		{
			reader.ReadInt32(); // vector code
			int messages_len = reader.ReadInt32();
			this.messages = new List<int>(messages_len);
			for (int messages_index = 0; messages_index < messages_len; messages_index++)
			{
				int messages_element;
				messages_element = reader.ReadInt32();
				this.messages.Add(messages_element);
			}
			this.pts = reader.ReadInt32();
		}

		public override string ToString()
		{
			return String.Format("(updateReadMessages messages:{0} pts:{1})", Serializers.VectorToString(messages), pts);
		}
	}


	public class UpdateDeleteMessagesConstructor : Update
	{
		public List<int> messages;
		public int pts;

		public UpdateDeleteMessagesConstructor()
		{

		}

		public UpdateDeleteMessagesConstructor(List<int> messages, int pts)
		{
			this.messages = messages;
			this.pts = pts;
		}


		public Constructor Constructor
		{
			get { return Constructor.updateDeleteMessages; }
		}

		public override void Write(BinaryWriter writer)
		{
			writer.Write(0xa92bfe26);
			writer.Write(0x1cb5c415);
			writer.Write(this.messages.Count);
			foreach (int messages_element in this.messages)
			{
				writer.Write(messages_element);
			}
			writer.Write(this.pts);
		}

		public override void Read(BinaryReader reader)
		{
			reader.ReadInt32(); // vector code
			int messages_len = reader.ReadInt32();
			this.messages = new List<int>(messages_len);
			for (int messages_index = 0; messages_index < messages_len; messages_index++)
			{
				int messages_element;
				messages_element = reader.ReadInt32();
				this.messages.Add(messages_element);
			}
			this.pts = reader.ReadInt32();
		}

		public override string ToString()
		{
			return String.Format("(updateDeleteMessages messages:{0} pts:{1})", Serializers.VectorToString(messages), pts);
		}
	}


	public class UpdateRestoreMessagesConstructor : Update
	{
		public List<int> messages;
		public int pts;

		public UpdateRestoreMessagesConstructor()
		{

		}

		public UpdateRestoreMessagesConstructor(List<int> messages, int pts)
		{
			this.messages = messages;
			this.pts = pts;
		}


		public Constructor Constructor
		{
			get { return Constructor.updateRestoreMessages; }
		}

		public override void Write(BinaryWriter writer)
		{
			writer.Write(0xd15de04d);
			writer.Write(0x1cb5c415);
			writer.Write(this.messages.Count);
			foreach (int messages_element in this.messages)
			{
				writer.Write(messages_element);
			}
			writer.Write(this.pts);
		}

		public override void Read(BinaryReader reader)
		{
			reader.ReadInt32(); // vector code
			int messages_len = reader.ReadInt32();
			this.messages = new List<int>(messages_len);
			for (int messages_index = 0; messages_index < messages_len; messages_index++)
			{
				int messages_element;
				messages_element = reader.ReadInt32();
				this.messages.Add(messages_element);
			}
			this.pts = reader.ReadInt32();
		}

		public override string ToString()
		{
			return String.Format("(updateRestoreMessages messages:{0} pts:{1})", Serializers.VectorToString(messages), pts);
		}
	}


	public class UpdateUserTypingConstructor : Update
	{
		public int user_id;

		public UpdateUserTypingConstructor()
		{

		}

		public UpdateUserTypingConstructor(int user_id)
		{
			this.user_id = user_id;
		}


		public Constructor Constructor
		{
			get { return Constructor.updateUserTyping; }
		}

		public override void Write(BinaryWriter writer)
		{
			writer.Write(0x6baa8508);
			writer.Write(this.user_id);
		}

		public override void Read(BinaryReader reader)
		{
			this.user_id = reader.ReadInt32();
		}

		public override string ToString()
		{
			return String.Format("(updateUserTyping user_id:{0})", user_id);
		}
	}


	public class UpdateChatUserTypingConstructor : Update
	{
		public int chat_id;
		public int user_id;

		public UpdateChatUserTypingConstructor()
		{

		}

		public UpdateChatUserTypingConstructor(int chat_id, int user_id)
		{
			this.chat_id = chat_id;
			this.user_id = user_id;
		}


		public Constructor Constructor
		{
			get { return Constructor.updateChatUserTyping; }
		}

		public override void Write(BinaryWriter writer)
		{
			writer.Write(0x3c46cfe6);
			writer.Write(this.chat_id);
			writer.Write(this.user_id);
		}

		public override void Read(BinaryReader reader)
		{
			this.chat_id = reader.ReadInt32();
			this.user_id = reader.ReadInt32();
		}

		public override string ToString()
		{
			return String.Format("(updateChatUserTyping chat_id:{0} user_id:{1})", chat_id, user_id);
		}
	}


	public class UpdateChatParticipantsConstructor : Update
	{
		public ChatParticipants participants;

		public UpdateChatParticipantsConstructor()
		{

		}

		public UpdateChatParticipantsConstructor(ChatParticipants participants)
		{
			this.participants = participants;
		}


		public Constructor Constructor
		{
			get { return Constructor.updateChatParticipants; }
		}

		public override void Write(BinaryWriter writer)
		{
			writer.Write(0x07761198);
			this.participants.Write(writer);
		}

		public override void Read(BinaryReader reader)
		{
			this.participants = TL.Parse<ChatParticipants>(reader);
		}

		public override string ToString()
		{
			return String.Format("(updateChatParticipants participants:{0})", participants);
		}
	}


	public class UpdateUserStatusConstructor : Update
	{
		public int user_id;
		public UserStatus status;

		public UpdateUserStatusConstructor()
		{

		}

		public UpdateUserStatusConstructor(int user_id, UserStatus status)
		{
			this.user_id = user_id;
			this.status = status;
		}


		public Constructor Constructor
		{
			get { return Constructor.updateUserStatus; }
		}

		public override void Write(BinaryWriter writer)
		{
			writer.Write(0x1bfbd823);
			writer.Write(this.user_id);
			this.status.Write(writer);
		}

		public override void Read(BinaryReader reader)
		{
			this.user_id = reader.ReadInt32();
			this.status = TL.Parse<UserStatus>(reader);
		}

		public override string ToString()
		{
			return String.Format("(updateUserStatus user_id:{0} status:{1})", user_id, status);
		}
	}


	public class UpdateUserNameConstructor : Update
	{
		public int user_id;
		public string first_name;
		public string last_name;

		public UpdateUserNameConstructor()
		{

		}

		public UpdateUserNameConstructor(int user_id, string first_name, string last_name)
		{
			this.user_id = user_id;
			this.first_name = first_name;
			this.last_name = last_name;
		}


		public Constructor Constructor
		{
			get { return Constructor.updateUserName; }
		}

		public override void Write(BinaryWriter writer)
		{
			writer.Write(0xda22d9ad);
			writer.Write(this.user_id);
			Serializers.String.write(writer, this.first_name);
			Serializers.String.write(writer, this.last_name);
		}

		public override void Read(BinaryReader reader)
		{
			this.user_id = reader.ReadInt32();
			this.first_name = Serializers.String.read(reader);
			this.last_name = Serializers.String.read(reader);
		}

		public override string ToString()
		{
			return String.Format("(updateUserName user_id:{0} first_name:'{1}' last_name:'{2}')", user_id, first_name, last_name);
		}
	}


	public class UpdateUserPhotoConstructor : Update
	{
		public int user_id;
		public int date;
		public UserProfilePhoto photo;
		public bool previous;

		public UpdateUserPhotoConstructor()
		{

		}

		public UpdateUserPhotoConstructor(int user_id, int date, UserProfilePhoto photo, bool previous)
		{
			this.user_id = user_id;
			this.date = date;
			this.photo = photo;
			this.previous = previous;
		}


		public Constructor Constructor
		{
			get { return Constructor.updateUserPhoto; }
		}

		public override void Write(BinaryWriter writer)
		{
			writer.Write(0x95313b0c);
			writer.Write(this.user_id);
			writer.Write(this.date);
			this.photo.Write(writer);
			writer.Write(this.previous ? 0x997275b5 : 0xbc799737);
		}

		public override void Read(BinaryReader reader)
		{
			this.user_id = reader.ReadInt32();
			this.date = reader.ReadInt32();
			this.photo = TL.Parse<UserProfilePhoto>(reader);
			this.previous = reader.ReadUInt32() == 0x997275b5;
		}

		public override string ToString()
		{
			return String.Format("(updateUserPhoto user_id:{0} date:{1} photo:{2} previous:{3})", user_id, date, photo, previous);
		}
	}


	public class UpdateContactRegisteredConstructor : Update
	{
		public int user_id;
		public int date;

		public UpdateContactRegisteredConstructor()
		{

		}

		public UpdateContactRegisteredConstructor(int user_id, int date)
		{
			this.user_id = user_id;
			this.date = date;
		}


		public Constructor Constructor
		{
			get { return Constructor.updateContactRegistered; }
		}

		public override void Write(BinaryWriter writer)
		{
			writer.Write(0x2575bbb9);
			writer.Write(this.user_id);
			writer.Write(this.date);
		}

		public override void Read(BinaryReader reader)
		{
			this.user_id = reader.ReadInt32();
			this.date = reader.ReadInt32();
		}

		public override string ToString()
		{
			return String.Format("(updateContactRegistered user_id:{0} date:{1})", user_id, date);
		}
	}


	public class UpdateContactLinkConstructor : Update
	{
		public int user_id;
		public contacts_MyLink my_link;
		public contacts_ForeignLink foreign_link;

		public UpdateContactLinkConstructor()
		{

		}

		public UpdateContactLinkConstructor(int user_id, contacts_MyLink my_link, contacts_ForeignLink foreign_link)
		{
			this.user_id = user_id;
			this.my_link = my_link;
			this.foreign_link = foreign_link;
		}


		public Constructor Constructor
		{
			get { return Constructor.updateContactLink; }
		}

		public override void Write(BinaryWriter writer)
		{
			writer.Write(0x51a48a9a);
			writer.Write(this.user_id);
			this.my_link.Write(writer);
			this.foreign_link.Write(writer);
		}

		public override void Read(BinaryReader reader)
		{
			this.user_id = reader.ReadInt32();
			this.my_link = TL.Parse<contacts_MyLink>(reader);
			this.foreign_link = TL.Parse<contacts_ForeignLink>(reader);
		}

		public override string ToString()
		{
			return String.Format("(updateContactLink user_id:{0} my_link:{1} foreign_link:{2})", user_id, my_link, foreign_link);
		}
	}


	public class UpdateActivationConstructor : Update
	{
		public int user_id;

		public UpdateActivationConstructor()
		{

		}

		public UpdateActivationConstructor(int user_id)
		{
			this.user_id = user_id;
		}


		public Constructor Constructor
		{
			get { return Constructor.updateActivation; }
		}

		public override void Write(BinaryWriter writer)
		{
			writer.Write(0x6f690963);
			writer.Write(this.user_id);
		}

		public override void Read(BinaryReader reader)
		{
			this.user_id = reader.ReadInt32();
		}

		public override string ToString()
		{
			return String.Format("(updateActivation user_id:{0})", user_id);
		}
	}


	public class UpdateNewAuthorizationConstructor : Update
	{
		public long auth_key_id;
		public int date;
		public string device;
		public string location;

		public UpdateNewAuthorizationConstructor()
		{

		}

		public UpdateNewAuthorizationConstructor(long auth_key_id, int date, string device, string location)
		{
			this.auth_key_id = auth_key_id;
			this.date = date;
			this.device = device;
			this.location = location;
		}


		public Constructor Constructor
		{
			get { return Constructor.updateNewAuthorization; }
		}

		public override void Write(BinaryWriter writer)
		{
			writer.Write(0x8f06529a);
			writer.Write(this.auth_key_id);
			writer.Write(this.date);
			Serializers.String.write(writer, this.device);
			Serializers.String.write(writer, this.location);
		}

		public override void Read(BinaryReader reader)
		{
			this.auth_key_id = reader.ReadInt64();
			this.date = reader.ReadInt32();
			this.device = Serializers.String.read(reader);
			this.location = Serializers.String.read(reader);
		}

		public override string ToString()
		{
			return String.Format("(updateNewAuthorization auth_key_id:{0} date:{1} device:'{2}' location:'{3}')", auth_key_id,
				date, device, location);
		}
	}


	public class Updates_stateConstructor : updates_State
	{
		public int pts;
		public int qts;
		public int date;
		public int seq;
		public int unread_count;

		public Updates_stateConstructor()
		{

		}

		public Updates_stateConstructor(int pts, int qts, int date, int seq, int unread_count)
		{
			this.pts = pts;
			this.qts = qts;
			this.date = date;
			this.seq = seq;
			this.unread_count = unread_count;
		}


		public Constructor Constructor
		{
			get { return Constructor.updates_state; }
		}

		public override void Write(BinaryWriter writer)
		{
			writer.Write(0xa56c2a3e);
			writer.Write(this.pts);
			writer.Write(this.qts);
			writer.Write(this.date);
			writer.Write(this.seq);
			writer.Write(this.unread_count);
		}

		public override void Read(BinaryReader reader)
		{
			this.pts = reader.ReadInt32();
			this.qts = reader.ReadInt32();
			this.date = reader.ReadInt32();
			this.seq = reader.ReadInt32();
			this.unread_count = reader.ReadInt32();
		}

		public override string ToString()
		{
			return String.Format("(updates_state pts:{0} qts:{1} date:{2} seq:{3} unread_count:{4})", pts, qts, date, seq,
				unread_count);
		}
	}


	public class Updates_differenceEmptyConstructor : updates_Difference
	{
		public int date;
		public int seq;

		public Updates_differenceEmptyConstructor()
		{

		}

		public Updates_differenceEmptyConstructor(int date, int seq)
		{
			this.date = date;
			this.seq = seq;
		}


		public Constructor Constructor
		{
			get { return Constructor.updates_differenceEmpty; }
		}

		public override void Write(BinaryWriter writer)
		{
			writer.Write(0x5d75a138);
			writer.Write(this.date);
			writer.Write(this.seq);
		}

		public override void Read(BinaryReader reader)
		{
			this.date = reader.ReadInt32();
			this.seq = reader.ReadInt32();
		}

		public override string ToString()
		{
			return String.Format("(updates_differenceEmpty date:{0} seq:{1})", date, seq);
		}
	}


	public class Updates_differenceConstructor : updates_Difference
	{
		public List<Message> new_messages;
		public List<EncryptedMessage> new_encrypted_messages;
		public List<Update> other_updates;
		public List<Chat> chats;
		public List<User> users;
		public updates_State state;

		public Updates_differenceConstructor()
		{

		}

		public Updates_differenceConstructor(List<Message> new_messages, List<EncryptedMessage> new_encrypted_messages,
			List<Update> other_updates, List<Chat> chats, List<User> users, updates_State state)
		{
			this.new_messages = new_messages;
			this.new_encrypted_messages = new_encrypted_messages;
			this.other_updates = other_updates;
			this.chats = chats;
			this.users = users;
			this.state = state;
		}


		public Constructor Constructor
		{
			get { return Constructor.updates_difference; }
		}

		public override void Write(BinaryWriter writer)
		{
			writer.Write(0x00f49ca0);
			writer.Write(0x1cb5c415);
			writer.Write(this.new_messages.Count);
			foreach (Message new_messages_element in this.new_messages)
			{
				new_messages_element.Write(writer);
			}
			writer.Write(0x1cb5c415);
			writer.Write(this.new_encrypted_messages.Count);
			foreach (EncryptedMessage new_encrypted_messages_element in this.new_encrypted_messages)
			{
				new_encrypted_messages_element.Write(writer);
			}
			writer.Write(0x1cb5c415);
			writer.Write(this.other_updates.Count);
			foreach (Update other_updates_element in this.other_updates)
			{
				other_updates_element.Write(writer);
			}
			writer.Write(0x1cb5c415);
			writer.Write(this.chats.Count);
			foreach (Chat chats_element in this.chats)
			{
				chats_element.Write(writer);
			}
			writer.Write(0x1cb5c415);
			writer.Write(this.users.Count);
			foreach (User users_element in this.users)
			{
				users_element.Write(writer);
			}
			this.state.Write(writer);
		}

		public override void Read(BinaryReader reader)
		{
			reader.ReadInt32(); // vector code
			int new_messages_len = reader.ReadInt32();
			this.new_messages = new List<Message>(new_messages_len);
			for (int new_messages_index = 0; new_messages_index < new_messages_len; new_messages_index++)
			{
				Message new_messages_element;
				new_messages_element = TL.Parse<Message>(reader);
				this.new_messages.Add(new_messages_element);
			}
			reader.ReadInt32(); // vector code
			int new_encrypted_messages_len = reader.ReadInt32();
			this.new_encrypted_messages = new List<EncryptedMessage>(new_encrypted_messages_len);
			for (int new_encrypted_messages_index = 0;
				new_encrypted_messages_index < new_encrypted_messages_len;
				new_encrypted_messages_index++)
			{
				EncryptedMessage new_encrypted_messages_element;
				new_encrypted_messages_element = TL.Parse<EncryptedMessage>(reader);
				this.new_encrypted_messages.Add(new_encrypted_messages_element);
			}
			reader.ReadInt32(); // vector code
			int other_updates_len = reader.ReadInt32();
			this.other_updates = new List<Update>(other_updates_len);
			for (int other_updates_index = 0; other_updates_index < other_updates_len; other_updates_index++)
			{
				Update other_updates_element;
				other_updates_element = TL.Parse<Update>(reader);
				this.other_updates.Add(other_updates_element);
			}
			reader.ReadInt32(); // vector code
			int chats_len = reader.ReadInt32();
			this.chats = new List<Chat>(chats_len);
			for (int chats_index = 0; chats_index < chats_len; chats_index++)
			{
				Chat chats_element;
				chats_element = TL.Parse<Chat>(reader);
				this.chats.Add(chats_element);
			}
			reader.ReadInt32(); // vector code
			int users_len = reader.ReadInt32();
			this.users = new List<User>(users_len);
			for (int users_index = 0; users_index < users_len; users_index++)
			{
				User users_element;
				users_element = TL.Parse<User>(reader);
				this.users.Add(users_element);
			}
			this.state = TL.Parse<updates_State>(reader);
		}

		public override string ToString()
		{
			return
				String.Format(
					"(updates_difference new_messages:{0} new_encrypted_messages:{1} other_updates:{2} chats:{3} users:{4} state:{5})",
					Serializers.VectorToString(new_messages), Serializers.VectorToString(new_encrypted_messages),
					Serializers.VectorToString(other_updates), Serializers.VectorToString(chats), Serializers.VectorToString(users),
					state);
		}
	}


	public class Updates_differenceSliceConstructor : updates_Difference
	{
		public List<Message> new_messages;
		public List<EncryptedMessage> new_encrypted_messages;
		public List<Update> other_updates;
		public List<Chat> chats;
		public List<User> users;
		public updates_State intermediate_state;

		public Updates_differenceSliceConstructor()
		{

		}

		public Updates_differenceSliceConstructor(List<Message> new_messages, List<EncryptedMessage> new_encrypted_messages,
			List<Update> other_updates, List<Chat> chats, List<User> users, updates_State intermediate_state)
		{
			this.new_messages = new_messages;
			this.new_encrypted_messages = new_encrypted_messages;
			this.other_updates = other_updates;
			this.chats = chats;
			this.users = users;
			this.intermediate_state = intermediate_state;
		}


		public Constructor Constructor
		{
			get { return Constructor.updates_differenceSlice; }
		}

		public override void Write(BinaryWriter writer)
		{
			writer.Write(0xa8fb1981);
			writer.Write(0x1cb5c415);
			writer.Write(this.new_messages.Count);
			foreach (Message new_messages_element in this.new_messages)
			{
				new_messages_element.Write(writer);
			}
			writer.Write(0x1cb5c415);
			writer.Write(this.new_encrypted_messages.Count);
			foreach (EncryptedMessage new_encrypted_messages_element in this.new_encrypted_messages)
			{
				new_encrypted_messages_element.Write(writer);
			}
			writer.Write(0x1cb5c415);
			writer.Write(this.other_updates.Count);
			foreach (Update other_updates_element in this.other_updates)
			{
				other_updates_element.Write(writer);
			}
			writer.Write(0x1cb5c415);
			writer.Write(this.chats.Count);
			foreach (Chat chats_element in this.chats)
			{
				chats_element.Write(writer);
			}
			writer.Write(0x1cb5c415);
			writer.Write(this.users.Count);
			foreach (User users_element in this.users)
			{
				users_element.Write(writer);
			}
			this.intermediate_state.Write(writer);
		}

		public override void Read(BinaryReader reader)
		{
			reader.ReadInt32(); // vector code
			int new_messages_len = reader.ReadInt32();
			this.new_messages = new List<Message>(new_messages_len);
			for (int new_messages_index = 0; new_messages_index < new_messages_len; new_messages_index++)
			{
				Message new_messages_element;
				new_messages_element = TL.Parse<Message>(reader);
				this.new_messages.Add(new_messages_element);
			}
			reader.ReadInt32(); // vector code
			int new_encrypted_messages_len = reader.ReadInt32();
			this.new_encrypted_messages = new List<EncryptedMessage>(new_encrypted_messages_len);
			for (int new_encrypted_messages_index = 0;
				new_encrypted_messages_index < new_encrypted_messages_len;
				new_encrypted_messages_index++)
			{
				EncryptedMessage new_encrypted_messages_element;
				new_encrypted_messages_element = TL.Parse<EncryptedMessage>(reader);
				this.new_encrypted_messages.Add(new_encrypted_messages_element);
			}
			reader.ReadInt32(); // vector code
			int other_updates_len = reader.ReadInt32();
			this.other_updates = new List<Update>(other_updates_len);
			for (int other_updates_index = 0; other_updates_index < other_updates_len; other_updates_index++)
			{
				Update other_updates_element;
				other_updates_element = TL.Parse<Update>(reader);
				this.other_updates.Add(other_updates_element);
			}
			reader.ReadInt32(); // vector code
			int chats_len = reader.ReadInt32();
			this.chats = new List<Chat>(chats_len);
			for (int chats_index = 0; chats_index < chats_len; chats_index++)
			{
				Chat chats_element;
				chats_element = TL.Parse<Chat>(reader);
				this.chats.Add(chats_element);
			}
			reader.ReadInt32(); // vector code
			int users_len = reader.ReadInt32();
			this.users = new List<User>(users_len);
			for (int users_index = 0; users_index < users_len; users_index++)
			{
				User users_element;
				users_element = TL.Parse<User>(reader);
				this.users.Add(users_element);
			}
			this.intermediate_state = TL.Parse<updates_State>(reader);
		}

		public override string ToString()
		{
			return
				String.Format(
					"(updates_differenceSlice new_messages:{0} new_encrypted_messages:{1} other_updates:{2} chats:{3} users:{4} intermediate_state:{5})",
					Serializers.VectorToString(new_messages), Serializers.VectorToString(new_encrypted_messages),
					Serializers.VectorToString(other_updates), Serializers.VectorToString(chats), Serializers.VectorToString(users),
					intermediate_state);
		}
	}


	public class UpdatesTooLongConstructor : Updates
	{

		public UpdatesTooLongConstructor()
		{

		}



		public Constructor Constructor
		{
			get { return Constructor.updatesTooLong; }
		}

		public override void Write(BinaryWriter writer)
		{
			writer.Write(0xe317af7e);
		}

		public override void Read(BinaryReader reader)
		{
		}

		public override string ToString()
		{
			return String.Format("(updatesTooLong)");
		}
	}


	public class UpdateShortMessageConstructor : Updates
	{
		public int id;
		public int from_id;
		public string message;
		public int pts;
		public int date;
		public int seq;

		public UpdateShortMessageConstructor()
		{

		}

		public UpdateShortMessageConstructor(int id, int from_id, string message, int pts, int date, int seq)
		{
			this.id = id;
			this.from_id = from_id;
			this.message = message;
			this.pts = pts;
			this.date = date;
			this.seq = seq;
		}


		public Constructor Constructor
		{
			get { return Constructor.updateShortMessage; }
		}

		public override void Write(BinaryWriter writer)
		{
			writer.Write(0xd3f45784);
			writer.Write(this.id);
			writer.Write(this.from_id);
			Serializers.String.write(writer, this.message);
			writer.Write(this.pts);
			writer.Write(this.date);
			writer.Write(this.seq);
		}

		public override void Read(BinaryReader reader)
		{
			this.id = reader.ReadInt32();
			this.from_id = reader.ReadInt32();
			this.message = Serializers.String.read(reader);
			this.pts = reader.ReadInt32();
			this.date = reader.ReadInt32();
			this.seq = reader.ReadInt32();
		}

		public override string ToString()
		{
			return String.Format("(updateShortMessage id:{0} from_id:{1} message:'{2}' pts:{3} date:{4} seq:{5})", id, from_id,
				message, pts, date, seq);
		}
	}


	public class UpdateShortChatMessageConstructor : Updates
	{
		public int id;
		public int from_id;
		public int chat_id;
		public string message;
		public int pts;
		public int date;
		public int seq;

		public UpdateShortChatMessageConstructor()
		{

		}

		public UpdateShortChatMessageConstructor(int id, int from_id, int chat_id, string message, int pts, int date, int seq)
		{
			this.id = id;
			this.from_id = from_id;
			this.chat_id = chat_id;
			this.message = message;
			this.pts = pts;
			this.date = date;
			this.seq = seq;
		}


		public Constructor Constructor
		{
			get { return Constructor.updateShortChatMessage; }
		}

		public override void Write(BinaryWriter writer)
		{
			writer.Write(0x2b2fbd4e);
			writer.Write(this.id);
			writer.Write(this.from_id);
			writer.Write(this.chat_id);
			Serializers.String.write(writer, this.message);
			writer.Write(this.pts);
			writer.Write(this.date);
			writer.Write(this.seq);
		}

		public override void Read(BinaryReader reader)
		{
			this.id = reader.ReadInt32();
			this.from_id = reader.ReadInt32();
			this.chat_id = reader.ReadInt32();
			this.message = Serializers.String.read(reader);
			this.pts = reader.ReadInt32();
			this.date = reader.ReadInt32();
			this.seq = reader.ReadInt32();
		}

		public override string ToString()
		{
			return String.Format(
				"(updateShortChatMessage id:{0} from_id:{1} chat_id:{2} message:'{3}' pts:{4} date:{5} seq:{6})", id, from_id,
				chat_id, message, pts, date, seq);
		}
	}


	public class UpdateShortConstructor : Updates
	{
		public Update update;
		public int date;

		public UpdateShortConstructor()
		{

		}

		public UpdateShortConstructor(Update update, int date)
		{
			this.update = update;
			this.date = date;
		}


		public Constructor Constructor
		{
			get { return Constructor.updateShort; }
		}

		public override void Write(BinaryWriter writer)
		{
			writer.Write(0x78d4dec1);
			this.update.Write(writer);
			writer.Write(this.date);
		}

		public override void Read(BinaryReader reader)
		{
			this.update = TL.Parse<Update>(reader);
			this.date = reader.ReadInt32();
		}

		public override string ToString()
		{
			return String.Format("(updateShort update:{0} date:{1})", update, date);
		}
	}


	public class UpdatesCombinedConstructor : Updates
	{
		public List<Update> updates;
		public List<User> users;
		public List<Chat> chats;
		public int date;
		public int seq_start;
		public int seq;

		public UpdatesCombinedConstructor()
		{

		}

		public UpdatesCombinedConstructor(List<Update> updates, List<User> users, List<Chat> chats, int date, int seq_start,
			int seq)
		{
			this.updates = updates;
			this.users = users;
			this.chats = chats;
			this.date = date;
			this.seq_start = seq_start;
			this.seq = seq;
		}


		public Constructor Constructor
		{
			get { return Constructor.updatesCombined; }
		}

		public override void Write(BinaryWriter writer)
		{
			writer.Write(0x725b04c3);
			writer.Write(0x1cb5c415);
			writer.Write(this.updates.Count);
			foreach (Update updates_element in this.updates)
			{
				updates_element.Write(writer);
			}
			writer.Write(0x1cb5c415);
			writer.Write(this.users.Count);
			foreach (User users_element in this.users)
			{
				users_element.Write(writer);
			}
			writer.Write(0x1cb5c415);
			writer.Write(this.chats.Count);
			foreach (Chat chats_element in this.chats)
			{
				chats_element.Write(writer);
			}
			writer.Write(this.date);
			writer.Write(this.seq_start);
			writer.Write(this.seq);
		}

		public override void Read(BinaryReader reader)
		{
			reader.ReadInt32(); // vector code
			int updates_len = reader.ReadInt32();
			this.updates = new List<Update>(updates_len);
			for (int updates_index = 0; updates_index < updates_len; updates_index++)
			{
				Update updates_element;
				updates_element = TL.Parse<Update>(reader);
				this.updates.Add(updates_element);
			}
			reader.ReadInt32(); // vector code
			int users_len = reader.ReadInt32();
			this.users = new List<User>(users_len);
			for (int users_index = 0; users_index < users_len; users_index++)
			{
				User users_element;
				users_element = TL.Parse<User>(reader);
				this.users.Add(users_element);
			}
			reader.ReadInt32(); // vector code
			int chats_len = reader.ReadInt32();
			this.chats = new List<Chat>(chats_len);
			for (int chats_index = 0; chats_index < chats_len; chats_index++)
			{
				Chat chats_element;
				chats_element = TL.Parse<Chat>(reader);
				this.chats.Add(chats_element);
			}
			this.date = reader.ReadInt32();
			this.seq_start = reader.ReadInt32();
			this.seq = reader.ReadInt32();
		}

		public override string ToString()
		{
			return String.Format("(updatesCombined updates:{0} users:{1} chats:{2} date:{3} seq_start:{4} seq:{5})",
				Serializers.VectorToString(updates), Serializers.VectorToString(users), Serializers.VectorToString(chats), date,
				seq_start, seq);
		}
	}


	public class UpdatesConstructor : Updates
	{
		public List<Update> updates;
		public List<User> users;
		public List<Chat> chats;
		public int date;
		public int seq;

		public UpdatesConstructor()
		{

		}

		public UpdatesConstructor(List<Update> updates, List<User> users, List<Chat> chats, int date, int seq)
		{
			this.updates = updates;
			this.users = users;
			this.chats = chats;
			this.date = date;
			this.seq = seq;
		}


		public Constructor Constructor
		{
			get { return Constructor.updates; }
		}

		public override void Write(BinaryWriter writer)
		{
			writer.Write(0x74ae4240);
			writer.Write(0x1cb5c415);
			writer.Write(this.updates.Count);
			foreach (Update updates_element in this.updates)
			{
				updates_element.Write(writer);
			}
			writer.Write(0x1cb5c415);
			writer.Write(this.users.Count);
			foreach (User users_element in this.users)
			{
				users_element.Write(writer);
			}
			writer.Write(0x1cb5c415);
			writer.Write(this.chats.Count);
			foreach (Chat chats_element in this.chats)
			{
				chats_element.Write(writer);
			}
			writer.Write(this.date);
			writer.Write(this.seq);
		}

		public override void Read(BinaryReader reader)
		{
			reader.ReadInt32(); // vector code
			int updates_len = reader.ReadInt32();
			this.updates = new List<Update>(updates_len);
			for (int updates_index = 0; updates_index < updates_len; updates_index++)
			{
				Update updates_element;
				updates_element = TL.Parse<Update>(reader);
				this.updates.Add(updates_element);
			}
			reader.ReadInt32(); // vector code
			int users_len = reader.ReadInt32();
			this.users = new List<User>(users_len);
			for (int users_index = 0; users_index < users_len; users_index++)
			{
				User users_element;
				users_element = TL.Parse<User>(reader);
				this.users.Add(users_element);
			}
			reader.ReadInt32(); // vector code
			int chats_len = reader.ReadInt32();
			this.chats = new List<Chat>(chats_len);
			for (int chats_index = 0; chats_index < chats_len; chats_index++)
			{
				Chat chats_element;
				chats_element = TL.Parse<Chat>(reader);
				this.chats.Add(chats_element);
			}
			this.date = reader.ReadInt32();
			this.seq = reader.ReadInt32();
		}

		public override string ToString()
		{
			return String.Format("(updates updates:{0} users:{1} chats:{2} date:{3} seq:{4})",
				Serializers.VectorToString(updates), Serializers.VectorToString(users), Serializers.VectorToString(chats), date, seq);
		}
	}


	public class Photos_photosConstructor : photos_Photos
	{
		public List<Photo> photos;
		public List<User> users;

		public Photos_photosConstructor()
		{

		}

		public Photos_photosConstructor(List<Photo> photos, List<User> users)
		{
			this.photos = photos;
			this.users = users;
		}


		public Constructor Constructor
		{
			get { return Constructor.photos_photos; }
		}

		public override void Write(BinaryWriter writer)
		{
			writer.Write(0x8dca6aa5);
			writer.Write(0x1cb5c415);
			writer.Write(this.photos.Count);
			foreach (Photo photos_element in this.photos)
			{
				photos_element.Write(writer);
			}
			writer.Write(0x1cb5c415);
			writer.Write(this.users.Count);
			foreach (User users_element in this.users)
			{
				users_element.Write(writer);
			}
		}

		public override void Read(BinaryReader reader)
		{
			reader.ReadInt32(); // vector code
			int photos_len = reader.ReadInt32();
			this.photos = new List<Photo>(photos_len);
			for (int photos_index = 0; photos_index < photos_len; photos_index++)
			{
				Photo photos_element;
				photos_element = TL.Parse<Photo>(reader);
				this.photos.Add(photos_element);
			}
			reader.ReadInt32(); // vector code
			int users_len = reader.ReadInt32();
			this.users = new List<User>(users_len);
			for (int users_index = 0; users_index < users_len; users_index++)
			{
				User users_element;
				users_element = TL.Parse<User>(reader);
				this.users.Add(users_element);
			}
		}

		public override string ToString()
		{
			return String.Format("(photos_photos photos:{0} users:{1})", Serializers.VectorToString(photos),
				Serializers.VectorToString(users));
		}
	}


	public class Photos_photosSliceConstructor : photos_Photos
	{
		public int count;
		public List<Photo> photos;
		public List<User> users;

		public Photos_photosSliceConstructor()
		{

		}

		public Photos_photosSliceConstructor(int count, List<Photo> photos, List<User> users)
		{
			this.count = count;
			this.photos = photos;
			this.users = users;
		}


		public Constructor Constructor
		{
			get { return Constructor.photos_photosSlice; }
		}

		public override void Write(BinaryWriter writer)
		{
			writer.Write(0x15051f54);
			writer.Write(this.count);
			writer.Write(0x1cb5c415);
			writer.Write(this.photos.Count);
			foreach (Photo photos_element in this.photos)
			{
				photos_element.Write(writer);
			}
			writer.Write(0x1cb5c415);
			writer.Write(this.users.Count);
			foreach (User users_element in this.users)
			{
				users_element.Write(writer);
			}
		}

		public override void Read(BinaryReader reader)
		{
			this.count = reader.ReadInt32();
			reader.ReadInt32(); // vector code
			int photos_len = reader.ReadInt32();
			this.photos = new List<Photo>(photos_len);
			for (int photos_index = 0; photos_index < photos_len; photos_index++)
			{
				Photo photos_element;
				photos_element = TL.Parse<Photo>(reader);
				this.photos.Add(photos_element);
			}
			reader.ReadInt32(); // vector code
			int users_len = reader.ReadInt32();
			this.users = new List<User>(users_len);
			for (int users_index = 0; users_index < users_len; users_index++)
			{
				User users_element;
				users_element = TL.Parse<User>(reader);
				this.users.Add(users_element);
			}
		}

		public override string ToString()
		{
			return String.Format("(photos_photosSlice count:{0} photos:{1} users:{2})", count, Serializers.VectorToString(photos),
				Serializers.VectorToString(users));
		}
	}


	public class Photos_photoConstructor : photos_Photo
	{
		public Photo photo;
		public List<User> users;

		public Photos_photoConstructor()
		{

		}

		public Photos_photoConstructor(Photo photo, List<User> users)
		{
			this.photo = photo;
			this.users = users;
		}


		public Constructor Constructor
		{
			get { return Constructor.photos_photo; }
		}

		public override void Write(BinaryWriter writer)
		{
			writer.Write(0x20212ca8);
			this.photo.Write(writer);
			writer.Write(0x1cb5c415);
			writer.Write(this.users.Count);
			foreach (User users_element in this.users)
			{
				users_element.Write(writer);
			}
		}

		public override void Read(BinaryReader reader)
		{
			this.photo = TL.Parse<Photo>(reader);
			reader.ReadInt32(); // vector code
			int users_len = reader.ReadInt32();
			this.users = new List<User>(users_len);
			for (int users_index = 0; users_index < users_len; users_index++)
			{
				User users_element;
				users_element = TL.Parse<User>(reader);
				this.users.Add(users_element);
			}
		}

		public override string ToString()
		{
			return String.Format("(photos_photo photo:{0} users:{1})", photo, Serializers.VectorToString(users));
		}
	}


	public class Upload_fileConstructor : upload_File
	{
		public storage_FileType type;
		public int mtime;
		public byte[] bytes;

		public Upload_fileConstructor()
		{

		}

		public Upload_fileConstructor(storage_FileType type, int mtime, byte[] bytes)
		{
			this.type = type;
			this.mtime = mtime;
			this.bytes = bytes;
		}


		public Constructor Constructor
		{
			get { return Constructor.upload_file; }
		}

		public override void Write(BinaryWriter writer)
		{
			writer.Write(0x096a18d5);
			this.type.Write(writer);
			writer.Write(this.mtime);
			Serializers.Bytes.write(writer, this.bytes);
		}

		public override void Read(BinaryReader reader)
		{
			this.type = TL.Parse<storage_FileType>(reader);
			this.mtime = reader.ReadInt32();
			this.bytes = Serializers.Bytes.read(reader);
		}

		public override string ToString()
		{
			return String.Format("(upload_file type:{0} mtime:{1} bytes:{2})", type, mtime, BitConverter.ToString(bytes));
		}
	}


	public class DcOptionConstructor : DcOption
	{
		public int id;
		public string hostname;
		public string ip_address;
		public int port;

		public DcOptionConstructor()
		{

		}

		public DcOptionConstructor(int id, string hostname, string ip_address, int port)
		{
			this.id = id;
			this.hostname = hostname;
			this.ip_address = ip_address;
			this.port = port;
		}


		public Constructor Constructor
		{
			get { return Constructor.dcOption; }
		}

		public override void Write(BinaryWriter writer)
		{
			writer.Write(0x2ec2a43c);
			writer.Write(this.id);
			Serializers.String.write(writer, this.hostname);
			Serializers.String.write(writer, this.ip_address);
			writer.Write(this.port);
		}

		public override void Read(BinaryReader reader)
		{
			this.id = reader.ReadInt32();
			this.hostname = Serializers.String.read(reader);
			this.ip_address = Serializers.String.read(reader);
			this.port = reader.ReadInt32();
		}

		public override string ToString()
		{
			return String.Format("(dcOption id:{0} hostname:'{1}' ip_address:'{2}' port:{3})", id, hostname, ip_address, port);
		}
	}


	public class ConfigConstructor : Config
	{
		public int date;
		public bool test_mode;
		public int this_dc;
		public List<DcOption> dc_options;
		public int chat_size_max;

		public ConfigConstructor()
		{

		}

		public ConfigConstructor(int date, bool test_mode, int this_dc, List<DcOption> dc_options, int chat_size_max)
		{
			this.date = date;
			this.test_mode = test_mode;
			this.this_dc = this_dc;
			this.dc_options = dc_options;
			this.chat_size_max = chat_size_max;
		}


		public Constructor Constructor
		{
			get { return Constructor.config; }
		}

		public override void Write(BinaryWriter writer)
		{
			writer.Write(0x232d5905);
			writer.Write(this.date);
			writer.Write(this.test_mode ? 0x997275b5 : 0xbc799737);
			writer.Write(this.this_dc);
			writer.Write(0x1cb5c415);
			writer.Write(this.dc_options.Count);
			foreach (DcOption dc_options_element in this.dc_options)
			{
				dc_options_element.Write(writer);
			}
			writer.Write(this.chat_size_max);
		}

		public override void Read(BinaryReader reader)
		{
			this.date = reader.ReadInt32();
			var expires = reader.ReadInt32();
			this.test_mode = reader.ReadUInt32() == 0x997275b5;
			this.this_dc = reader.ReadInt32();
			reader.ReadInt32(); // vector code
			int dc_options_len = reader.ReadInt32();
			this.dc_options = new List<DcOption>(dc_options_len);
			for (int dc_options_index = 0; dc_options_index < dc_options_len; dc_options_index++)
			{
				DcOption dc_options_element;
				dc_options_element = TL.Parse<DcOption>(reader);
				this.dc_options.Add(dc_options_element);
			}
			this.chat_size_max = reader.ReadInt32();
		}

		public override string ToString()
		{
			return String.Format("(config date:{0} test_mode:{1} this_dc:{2} dc_options:{3} chat_size_max:{4})", date, test_mode,
				this_dc, Serializers.VectorToString(dc_options), chat_size_max);
		}
	}


	public class NearestDcConstructor : NearestDc
	{
		public string country;
		public int this_dc;
		public int nearest_dc;

		public NearestDcConstructor()
		{

		}

		public NearestDcConstructor(string country, int this_dc, int nearest_dc)
		{
			this.country = country;
			this.this_dc = this_dc;
			this.nearest_dc = nearest_dc;
		}


		public Constructor Constructor
		{
			get { return Constructor.nearestDc; }
		}

		public override void Write(BinaryWriter writer)
		{
			writer.Write(0x8e1a1775);
			Serializers.String.write(writer, this.country);
			writer.Write(this.this_dc);
			writer.Write(this.nearest_dc);
		}

		public override void Read(BinaryReader reader)
		{
			this.country = Serializers.String.read(reader);
			this.this_dc = reader.ReadInt32();
			this.nearest_dc = reader.ReadInt32();
		}

		public override string ToString()
		{
			return String.Format("(nearestDc country:'{0}' this_dc:{1} nearest_dc:{2})", country, this_dc, nearest_dc);
		}
	}


	public class Help_appUpdateConstructor : help_AppUpdate
	{
		public int id;
		public bool critical;
		public string url;
		public string text;

		public Help_appUpdateConstructor()
		{

		}

		public Help_appUpdateConstructor(int id, bool critical, string url, string text)
		{
			this.id = id;
			this.critical = critical;
			this.url = url;
			this.text = text;
		}


		public Constructor Constructor
		{
			get { return Constructor.help_appUpdate; }
		}

		public override void Write(BinaryWriter writer)
		{
			writer.Write(0x8987f311);
			writer.Write(this.id);
			writer.Write(this.critical ? 0x997275b5 : 0xbc799737);
			Serializers.String.write(writer, this.url);
			Serializers.String.write(writer, this.text);
		}

		public override void Read(BinaryReader reader)
		{
			this.id = reader.ReadInt32();
			this.critical = reader.ReadUInt32() == 0x997275b5;
			this.url = Serializers.String.read(reader);
			this.text = Serializers.String.read(reader);
		}

		public override string ToString()
		{
			return String.Format("(help_appUpdate id:{0} critical:{1} url:'{2}' text:'{3}')", id, critical, url, text);
		}
	}


	public class Help_noAppUpdateConstructor : help_AppUpdate
	{

		public Help_noAppUpdateConstructor()
		{

		}



		public Constructor Constructor
		{
			get { return Constructor.help_noAppUpdate; }
		}

		public override void Write(BinaryWriter writer)
		{
			writer.Write(0xc45a6536);
		}

		public override void Read(BinaryReader reader)
		{
		}

		public override string ToString()
		{
			return String.Format("(help_noAppUpdate)");
		}
	}


	public class Help_inviteTextConstructor : help_InviteText
	{
		public string message;

		public Help_inviteTextConstructor()
		{

		}

		public Help_inviteTextConstructor(string message)
		{
			this.message = message;
		}


		public Constructor Constructor
		{
			get { return Constructor.help_inviteText; }
		}

		public override void Write(BinaryWriter writer)
		{
			writer.Write(0x18cb9f78);
			Serializers.String.write(writer, this.message);
		}

		public override void Read(BinaryReader reader)
		{
			this.message = Serializers.String.read(reader);
		}

		public override string ToString()
		{
			return String.Format("(help_inviteText message:'{0}')", message);
		}
	}


	public class Messages_statedMessagesLinksConstructor : messages_StatedMessages
	{
		public List<Message> messages;
		public List<Chat> chats;
		public List<User> users;
		public List<contacts_Link> links;
		public int pts;
		public int seq;

		public Messages_statedMessagesLinksConstructor()
		{

		}

		public Messages_statedMessagesLinksConstructor(List<Message> messages, List<Chat> chats, List<User> users,
			List<contacts_Link> links, int pts, int seq)
		{
			this.messages = messages;
			this.chats = chats;
			this.users = users;
			this.links = links;
			this.pts = pts;
			this.seq = seq;
		}


		public Constructor Constructor
		{
			get { return Constructor.messages_statedMessagesLinks; }
		}

		public override void Write(BinaryWriter writer)
		{
			writer.Write(0x3e74f5c6);
			writer.Write(0x1cb5c415);
			writer.Write(this.messages.Count);
			foreach (Message messages_element in this.messages)
			{
				messages_element.Write(writer);
			}
			writer.Write(0x1cb5c415);
			writer.Write(this.chats.Count);
			foreach (Chat chats_element in this.chats)
			{
				chats_element.Write(writer);
			}
			writer.Write(0x1cb5c415);
			writer.Write(this.users.Count);
			foreach (User users_element in this.users)
			{
				users_element.Write(writer);
			}
			writer.Write(0x1cb5c415);
			writer.Write(this.links.Count);
			foreach (contacts_Link links_element in this.links)
			{
				links_element.Write(writer);
			}
			writer.Write(this.pts);
			writer.Write(this.seq);
		}

		public override void Read(BinaryReader reader)
		{
			reader.ReadInt32(); // vector code
			int messages_len = reader.ReadInt32();
			this.messages = new List<Message>(messages_len);
			for (int messages_index = 0; messages_index < messages_len; messages_index++)
			{
				Message messages_element;
				messages_element = TL.Parse<Message>(reader);
				this.messages.Add(messages_element);
			}
			reader.ReadInt32(); // vector code
			int chats_len = reader.ReadInt32();
			this.chats = new List<Chat>(chats_len);
			for (int chats_index = 0; chats_index < chats_len; chats_index++)
			{
				Chat chats_element;
				chats_element = TL.Parse<Chat>(reader);
				this.chats.Add(chats_element);
			}
			reader.ReadInt32(); // vector code
			int users_len = reader.ReadInt32();
			this.users = new List<User>(users_len);
			for (int users_index = 0; users_index < users_len; users_index++)
			{
				User users_element;
				users_element = TL.Parse<User>(reader);
				this.users.Add(users_element);
			}
			reader.ReadInt32(); // vector code
			int links_len = reader.ReadInt32();
			this.links = new List<contacts_Link>(links_len);
			for (int links_index = 0; links_index < links_len; links_index++)
			{
				contacts_Link links_element;
				links_element = TL.Parse<contacts_Link>(reader);
				this.links.Add(links_element);
			}
			this.pts = reader.ReadInt32();
			this.seq = reader.ReadInt32();
		}

		public override string ToString()
		{
			return String.Format("(messages_statedMessagesLinks messages:{0} chats:{1} users:{2} links:{3} pts:{4} seq:{5})",
				Serializers.VectorToString(messages), Serializers.VectorToString(chats), Serializers.VectorToString(users),
				Serializers.VectorToString(links), pts, seq);
		}
	}


	public class Messages_statedMessageLinkConstructor : messages_StatedMessage
	{
		public Message message;
		public List<Chat> chats;
		public List<User> users;
		public List<contacts_Link> links;
		public int pts;
		public int seq;

		public Messages_statedMessageLinkConstructor()
		{

		}

		public Messages_statedMessageLinkConstructor(Message message, List<Chat> chats, List<User> users,
			List<contacts_Link> links, int pts, int seq)
		{
			this.message = message;
			this.chats = chats;
			this.users = users;
			this.links = links;
			this.pts = pts;
			this.seq = seq;
		}


		public Constructor Constructor
		{
			get { return Constructor.messages_statedMessageLink; }
		}

		public override void Write(BinaryWriter writer)
		{
			writer.Write(0xa9af2881);
			this.message.Write(writer);
			writer.Write(0x1cb5c415);
			writer.Write(this.chats.Count);
			foreach (Chat chats_element in this.chats)
			{
				chats_element.Write(writer);
			}
			writer.Write(0x1cb5c415);
			writer.Write(this.users.Count);
			foreach (User users_element in this.users)
			{
				users_element.Write(writer);
			}
			writer.Write(0x1cb5c415);
			writer.Write(this.links.Count);
			foreach (contacts_Link links_element in this.links)
			{
				links_element.Write(writer);
			}
			writer.Write(this.pts);
			writer.Write(this.seq);
		}

		public override void Read(BinaryReader reader)
		{
			this.message = TL.Parse<Message>(reader);
			reader.ReadInt32(); // vector code
			int chats_len = reader.ReadInt32();
			this.chats = new List<Chat>(chats_len);
			for (int chats_index = 0; chats_index < chats_len; chats_index++)
			{
				Chat chats_element;
				chats_element = TL.Parse<Chat>(reader);
				this.chats.Add(chats_element);
			}
			reader.ReadInt32(); // vector code
			int users_len = reader.ReadInt32();
			this.users = new List<User>(users_len);
			for (int users_index = 0; users_index < users_len; users_index++)
			{
				User users_element;
				users_element = TL.Parse<User>(reader);
				this.users.Add(users_element);
			}
			reader.ReadInt32(); // vector code
			int links_len = reader.ReadInt32();
			this.links = new List<contacts_Link>(links_len);
			for (int links_index = 0; links_index < links_len; links_index++)
			{
				contacts_Link links_element;
				links_element = TL.Parse<contacts_Link>(reader);
				this.links.Add(links_element);
			}
			this.pts = reader.ReadInt32();
			this.seq = reader.ReadInt32();
		}

		public override string ToString()
		{
			return String.Format("(messages_statedMessageLink message:{0} chats:{1} users:{2} links:{3} pts:{4} seq:{5})",
				message, Serializers.VectorToString(chats), Serializers.VectorToString(users), Serializers.VectorToString(links),
				pts, seq);
		}
	}


	public class Messages_sentMessageLinkConstructor : messages_SentMessage
	{
		public int id;
		public int date;
		public int pts;
		public int seq;
		public List<contacts_Link> links;

		public Messages_sentMessageLinkConstructor()
		{

		}

		public Messages_sentMessageLinkConstructor(int id, int date, int pts, int seq, List<contacts_Link> links)
		{
			this.id = id;
			this.date = date;
			this.pts = pts;
			this.seq = seq;
			this.links = links;
		}


		public Constructor Constructor
		{
			get { return Constructor.messages_sentMessageLink; }
		}

		public override void Write(BinaryWriter writer)
		{
			writer.Write(0xe9db4a3f);
			writer.Write(this.id);
			writer.Write(this.date);
			writer.Write(this.pts);
			writer.Write(this.seq);
			writer.Write(0x1cb5c415);
			writer.Write(this.links.Count);
			foreach (contacts_Link links_element in this.links)
			{
				links_element.Write(writer);
			}
		}

		public override void Read(BinaryReader reader)
		{
			this.id = reader.ReadInt32();
			this.date = reader.ReadInt32();
			this.pts = reader.ReadInt32();
			this.seq = reader.ReadInt32();
			reader.ReadInt32(); // vector code
			int links_len = reader.ReadInt32();
			this.links = new List<contacts_Link>(links_len);
			for (int links_index = 0; links_index < links_len; links_index++)
			{
				contacts_Link links_element;
				links_element = TL.Parse<contacts_Link>(reader);
				this.links.Add(links_element);
			}
		}

		public override string ToString()
		{
			return String.Format("(messages_sentMessageLink id:{0} date:{1} pts:{2} seq:{3} links:{4})", id, date, pts, seq,
				Serializers.VectorToString(links));
		}
	}


	public class InputGeoChatConstructor : InputGeoChat
	{
		public int chat_id;
		public long access_hash;

		public InputGeoChatConstructor()
		{

		}

		public InputGeoChatConstructor(int chat_id, long access_hash)
		{
			this.chat_id = chat_id;
			this.access_hash = access_hash;
		}


		public Constructor Constructor
		{
			get { return Constructor.inputGeoChat; }
		}

		public override void Write(BinaryWriter writer)
		{
			writer.Write(0x74d456fa);
			writer.Write(this.chat_id);
			writer.Write(this.access_hash);
		}

		public override void Read(BinaryReader reader)
		{
			this.chat_id = reader.ReadInt32();
			this.access_hash = reader.ReadInt64();
		}

		public override string ToString()
		{
			return String.Format("(inputGeoChat chat_id:{0} access_hash:{1})", chat_id, access_hash);
		}
	}


	public class InputNotifyGeoChatPeerConstructor : InputNotifyPeer
	{
		public InputGeoChat peer;

		public InputNotifyGeoChatPeerConstructor()
		{

		}

		public InputNotifyGeoChatPeerConstructor(InputGeoChat peer)
		{
			this.peer = peer;
		}


		public Constructor Constructor
		{
			get { return Constructor.inputNotifyGeoChatPeer; }
		}

		public override void Write(BinaryWriter writer)
		{
			writer.Write(0x4d8ddec8);
			this.peer.Write(writer);
		}

		public override void Read(BinaryReader reader)
		{
			this.peer = TL.Parse<InputGeoChat>(reader);
		}

		public override string ToString()
		{
			return String.Format("(inputNotifyGeoChatPeer peer:{0})", peer);
		}
	}


	public class GeoChatConstructor : Chat
	{
		public int id;
		public long access_hash;
		public string title;
		public string address;
		public string venue;
		public GeoPoint geo;
		public ChatPhoto photo;
		public int participants_count;
		public int date;
		public bool checked_in;
		public int version;

		public GeoChatConstructor()
		{

		}

		public GeoChatConstructor(int id, long access_hash, string title, string address, string venue, GeoPoint geo,
			ChatPhoto photo, int participants_count, int date, bool checked_in, int version)
		{
			this.id = id;
			this.access_hash = access_hash;
			this.title = title;
			this.address = address;
			this.venue = venue;
			this.geo = geo;
			this.photo = photo;
			this.participants_count = participants_count;
			this.date = date;
			this.checked_in = checked_in;
			this.version = version;
		}


		public Constructor Constructor
		{
			get { return Constructor.geoChat; }
		}

		public override void Write(BinaryWriter writer)
		{
			writer.Write(0x75eaea5a);
			writer.Write(this.id);
			writer.Write(this.access_hash);
			Serializers.String.write(writer, this.title);
			Serializers.String.write(writer, this.address);
			Serializers.String.write(writer, this.venue);
			this.geo.Write(writer);
			this.photo.Write(writer);
			writer.Write(this.participants_count);
			writer.Write(this.date);
			writer.Write(this.checked_in ? 0x997275b5 : 0xbc799737);
			writer.Write(this.version);
		}

		public override void Read(BinaryReader reader)
		{
			this.id = reader.ReadInt32();
			this.access_hash = reader.ReadInt64();
			this.title = Serializers.String.read(reader);
			this.address = Serializers.String.read(reader);
			this.venue = Serializers.String.read(reader);
			this.geo = TL.Parse<GeoPoint>(reader);
			this.photo = TL.Parse<ChatPhoto>(reader);
			this.participants_count = reader.ReadInt32();
			this.date = reader.ReadInt32();
			this.checked_in = reader.ReadUInt32() == 0x997275b5;
			this.version = reader.ReadInt32();
		}

		public override string ToString()
		{
			return
				String.Format(
					"(geoChat id:{0} access_hash:{1} title:'{2}' address:'{3}' venue:'{4}' geo:{5} photo:{6} participants_count:{7} date:{8} checked_in:{9} version:{10})",
					id, access_hash, title, address, venue, geo, photo, participants_count, date, checked_in, version);
		}
	}


	public class GeoChatMessageEmptyConstructor : GeoChatMessage
	{
		public int chat_id;
		public int id;

		public GeoChatMessageEmptyConstructor()
		{

		}

		public GeoChatMessageEmptyConstructor(int chat_id, int id)
		{
			this.chat_id = chat_id;
			this.id = id;
		}


		public Constructor Constructor
		{
			get { return Constructor.geoChatMessageEmpty; }
		}

		public override void Write(BinaryWriter writer)
		{
			writer.Write(0x60311a9b);
			writer.Write(this.chat_id);
			writer.Write(this.id);
		}

		public override void Read(BinaryReader reader)
		{
			this.chat_id = reader.ReadInt32();
			this.id = reader.ReadInt32();
		}

		public override string ToString()
		{
			return String.Format("(geoChatMessageEmpty chat_id:{0} id:{1})", chat_id, id);
		}
	}


	public class GeoChatMessageConstructor : GeoChatMessage
	{
		public int chat_id;
		public int id;
		public int from_id;
		public int date;
		public string message;
		public MessageMedia media;

		public GeoChatMessageConstructor()
		{

		}

		public GeoChatMessageConstructor(int chat_id, int id, int from_id, int date, string message, MessageMedia media)
		{
			this.chat_id = chat_id;
			this.id = id;
			this.from_id = from_id;
			this.date = date;
			this.message = message;
			this.media = media;
		}


		public Constructor Constructor
		{
			get { return Constructor.geoChatMessage; }
		}

		public override void Write(BinaryWriter writer)
		{
			writer.Write(0x4505f8e1);
			writer.Write(this.chat_id);
			writer.Write(this.id);
			writer.Write(this.from_id);
			writer.Write(this.date);
			Serializers.String.write(writer, this.message);
			this.media.Write(writer);
		}

		public override void Read(BinaryReader reader)
		{
			this.chat_id = reader.ReadInt32();
			this.id = reader.ReadInt32();
			this.from_id = reader.ReadInt32();
			this.date = reader.ReadInt32();
			this.message = Serializers.String.read(reader);
			this.media = TL.Parse<MessageMedia>(reader);
		}

		public override string ToString()
		{
			return String.Format("(geoChatMessage chat_id:{0} id:{1} from_id:{2} date:{3} message:'{4}' media:{5})", chat_id, id,
				from_id, date, message, media);
		}
	}


	public class GeoChatMessageServiceConstructor : GeoChatMessage
	{
		public int chat_id;
		public int id;
		public int from_id;
		public int date;
		public MessageAction action;

		public GeoChatMessageServiceConstructor()
		{

		}

		public GeoChatMessageServiceConstructor(int chat_id, int id, int from_id, int date, MessageAction action)
		{
			this.chat_id = chat_id;
			this.id = id;
			this.from_id = from_id;
			this.date = date;
			this.action = action;
		}


		public Constructor Constructor
		{
			get { return Constructor.geoChatMessageService; }
		}

		public override void Write(BinaryWriter writer)
		{
			writer.Write(0xd34fa24e);
			writer.Write(this.chat_id);
			writer.Write(this.id);
			writer.Write(this.from_id);
			writer.Write(this.date);
			this.action.Write(writer);
		}

		public override void Read(BinaryReader reader)
		{
			this.chat_id = reader.ReadInt32();
			this.id = reader.ReadInt32();
			this.from_id = reader.ReadInt32();
			this.date = reader.ReadInt32();
			this.action = TL.Parse<MessageAction>(reader);
		}

		public override string ToString()
		{
			return String.Format("(geoChatMessageService chat_id:{0} id:{1} from_id:{2} date:{3} action:{4})", chat_id, id,
				from_id, date, action);
		}
	}


	public class Geochats_statedMessageConstructor : geochats_StatedMessage
	{
		public GeoChatMessage message;
		public List<Chat> chats;
		public List<User> users;
		public int seq;

		public Geochats_statedMessageConstructor()
		{

		}

		public Geochats_statedMessageConstructor(GeoChatMessage message, List<Chat> chats, List<User> users, int seq)
		{
			this.message = message;
			this.chats = chats;
			this.users = users;
			this.seq = seq;
		}


		public Constructor Constructor
		{
			get { return Constructor.geochats_statedMessage; }
		}

		public override void Write(BinaryWriter writer)
		{
			writer.Write(0x17b1578b);
			this.message.Write(writer);
			writer.Write(0x1cb5c415);
			writer.Write(this.chats.Count);
			foreach (Chat chats_element in this.chats)
			{
				chats_element.Write(writer);
			}
			writer.Write(0x1cb5c415);
			writer.Write(this.users.Count);
			foreach (User users_element in this.users)
			{
				users_element.Write(writer);
			}
			writer.Write(this.seq);
		}

		public override void Read(BinaryReader reader)
		{
			this.message = TL.Parse<GeoChatMessage>(reader);
			reader.ReadInt32(); // vector code
			int chats_len = reader.ReadInt32();
			this.chats = new List<Chat>(chats_len);
			for (int chats_index = 0; chats_index < chats_len; chats_index++)
			{
				Chat chats_element;
				chats_element = TL.Parse<Chat>(reader);
				this.chats.Add(chats_element);
			}
			reader.ReadInt32(); // vector code
			int users_len = reader.ReadInt32();
			this.users = new List<User>(users_len);
			for (int users_index = 0; users_index < users_len; users_index++)
			{
				User users_element;
				users_element = TL.Parse<User>(reader);
				this.users.Add(users_element);
			}
			this.seq = reader.ReadInt32();
		}

		public override string ToString()
		{
			return String.Format("(geochats_statedMessage message:{0} chats:{1} users:{2} seq:{3})", message,
				Serializers.VectorToString(chats), Serializers.VectorToString(users), seq);
		}
	}


	public class Geochats_locatedConstructor : geochats_Located
	{
		public List<ChatLocated> results;
		public List<GeoChatMessage> messages;
		public List<Chat> chats;
		public List<User> users;

		public Geochats_locatedConstructor()
		{

		}

		public Geochats_locatedConstructor(List<ChatLocated> results, List<GeoChatMessage> messages, List<Chat> chats,
			List<User> users)
		{
			this.results = results;
			this.messages = messages;
			this.chats = chats;
			this.users = users;
		}


		public Constructor Constructor
		{
			get { return Constructor.geochats_located; }
		}

		public override void Write(BinaryWriter writer)
		{
			writer.Write(0x48feb267);
			writer.Write(0x1cb5c415);
			writer.Write(this.results.Count);
			foreach (ChatLocated results_element in this.results)
			{
				results_element.Write(writer);
			}
			writer.Write(0x1cb5c415);
			writer.Write(this.messages.Count);
			foreach (GeoChatMessage messages_element in this.messages)
			{
				messages_element.Write(writer);
			}
			writer.Write(0x1cb5c415);
			writer.Write(this.chats.Count);
			foreach (Chat chats_element in this.chats)
			{
				chats_element.Write(writer);
			}
			writer.Write(0x1cb5c415);
			writer.Write(this.users.Count);
			foreach (User users_element in this.users)
			{
				users_element.Write(writer);
			}
		}

		public override void Read(BinaryReader reader)
		{
			reader.ReadInt32(); // vector code
			int results_len = reader.ReadInt32();
			this.results = new List<ChatLocated>(results_len);
			for (int results_index = 0; results_index < results_len; results_index++)
			{
				ChatLocated results_element;
				results_element = TL.Parse<ChatLocated>(reader);
				this.results.Add(results_element);
			}
			reader.ReadInt32(); // vector code
			int messages_len = reader.ReadInt32();
			this.messages = new List<GeoChatMessage>(messages_len);
			for (int messages_index = 0; messages_index < messages_len; messages_index++)
			{
				GeoChatMessage messages_element;
				messages_element = TL.Parse<GeoChatMessage>(reader);
				this.messages.Add(messages_element);
			}
			reader.ReadInt32(); // vector code
			int chats_len = reader.ReadInt32();
			this.chats = new List<Chat>(chats_len);
			for (int chats_index = 0; chats_index < chats_len; chats_index++)
			{
				Chat chats_element;
				chats_element = TL.Parse<Chat>(reader);
				this.chats.Add(chats_element);
			}
			reader.ReadInt32(); // vector code
			int users_len = reader.ReadInt32();
			this.users = new List<User>(users_len);
			for (int users_index = 0; users_index < users_len; users_index++)
			{
				User users_element;
				users_element = TL.Parse<User>(reader);
				this.users.Add(users_element);
			}
		}

		public override string ToString()
		{
			return String.Format("(geochats_located results:{0} messages:{1} chats:{2} users:{3})",
				Serializers.VectorToString(results), Serializers.VectorToString(messages), Serializers.VectorToString(chats),
				Serializers.VectorToString(users));
		}
	}


	public class Geochats_messagesConstructor : geochats_Messages
	{
		public List<GeoChatMessage> messages;
		public List<Chat> chats;
		public List<User> users;

		public Geochats_messagesConstructor()
		{

		}

		public Geochats_messagesConstructor(List<GeoChatMessage> messages, List<Chat> chats, List<User> users)
		{
			this.messages = messages;
			this.chats = chats;
			this.users = users;
		}


		public Constructor Constructor
		{
			get { return Constructor.geochats_messages; }
		}

		public override void Write(BinaryWriter writer)
		{
			writer.Write(0xd1526db1);
			writer.Write(0x1cb5c415);
			writer.Write(this.messages.Count);
			foreach (GeoChatMessage messages_element in this.messages)
			{
				messages_element.Write(writer);
			}
			writer.Write(0x1cb5c415);
			writer.Write(this.chats.Count);
			foreach (Chat chats_element in this.chats)
			{
				chats_element.Write(writer);
			}
			writer.Write(0x1cb5c415);
			writer.Write(this.users.Count);
			foreach (User users_element in this.users)
			{
				users_element.Write(writer);
			}
		}

		public override void Read(BinaryReader reader)
		{
			reader.ReadInt32(); // vector code
			int messages_len = reader.ReadInt32();
			this.messages = new List<GeoChatMessage>(messages_len);
			for (int messages_index = 0; messages_index < messages_len; messages_index++)
			{
				GeoChatMessage messages_element;
				messages_element = TL.Parse<GeoChatMessage>(reader);
				this.messages.Add(messages_element);
			}
			reader.ReadInt32(); // vector code
			int chats_len = reader.ReadInt32();
			this.chats = new List<Chat>(chats_len);
			for (int chats_index = 0; chats_index < chats_len; chats_index++)
			{
				Chat chats_element;
				chats_element = TL.Parse<Chat>(reader);
				this.chats.Add(chats_element);
			}
			reader.ReadInt32(); // vector code
			int users_len = reader.ReadInt32();
			this.users = new List<User>(users_len);
			for (int users_index = 0; users_index < users_len; users_index++)
			{
				User users_element;
				users_element = TL.Parse<User>(reader);
				this.users.Add(users_element);
			}
		}

		public override string ToString()
		{
			return String.Format("(geochats_messages messages:{0} chats:{1} users:{2})", Serializers.VectorToString(messages),
				Serializers.VectorToString(chats), Serializers.VectorToString(users));
		}
	}


	public class Geochats_messagesSliceConstructor : geochats_Messages
	{
		public int count;
		public List<GeoChatMessage> messages;
		public List<Chat> chats;
		public List<User> users;

		public Geochats_messagesSliceConstructor()
		{

		}

		public Geochats_messagesSliceConstructor(int count, List<GeoChatMessage> messages, List<Chat> chats, List<User> users)
		{
			this.count = count;
			this.messages = messages;
			this.chats = chats;
			this.users = users;
		}


		public Constructor Constructor
		{
			get { return Constructor.geochats_messagesSlice; }
		}

		public override void Write(BinaryWriter writer)
		{
			writer.Write(0xbc5863e8);
			writer.Write(this.count);
			writer.Write(0x1cb5c415);
			writer.Write(this.messages.Count);
			foreach (GeoChatMessage messages_element in this.messages)
			{
				messages_element.Write(writer);
			}
			writer.Write(0x1cb5c415);
			writer.Write(this.chats.Count);
			foreach (Chat chats_element in this.chats)
			{
				chats_element.Write(writer);
			}
			writer.Write(0x1cb5c415);
			writer.Write(this.users.Count);
			foreach (User users_element in this.users)
			{
				users_element.Write(writer);
			}
		}

		public override void Read(BinaryReader reader)
		{
			this.count = reader.ReadInt32();
			reader.ReadInt32(); // vector code
			int messages_len = reader.ReadInt32();
			this.messages = new List<GeoChatMessage>(messages_len);
			for (int messages_index = 0; messages_index < messages_len; messages_index++)
			{
				GeoChatMessage messages_element;
				messages_element = TL.Parse<GeoChatMessage>(reader);
				this.messages.Add(messages_element);
			}
			reader.ReadInt32(); // vector code
			int chats_len = reader.ReadInt32();
			this.chats = new List<Chat>(chats_len);
			for (int chats_index = 0; chats_index < chats_len; chats_index++)
			{
				Chat chats_element;
				chats_element = TL.Parse<Chat>(reader);
				this.chats.Add(chats_element);
			}
			reader.ReadInt32(); // vector code
			int users_len = reader.ReadInt32();
			this.users = new List<User>(users_len);
			for (int users_index = 0; users_index < users_len; users_index++)
			{
				User users_element;
				users_element = TL.Parse<User>(reader);
				this.users.Add(users_element);
			}
		}

		public override string ToString()
		{
			return String.Format("(geochats_messagesSlice count:{0} messages:{1} chats:{2} users:{3})", count,
				Serializers.VectorToString(messages), Serializers.VectorToString(chats), Serializers.VectorToString(users));
		}
	}


	public class MessageActionGeoChatCreateConstructor : MessageAction
	{
		public string title;
		public string address;

		public MessageActionGeoChatCreateConstructor()
		{

		}

		public MessageActionGeoChatCreateConstructor(string title, string address)
		{
			this.title = title;
			this.address = address;
		}


		public Constructor Constructor
		{
			get { return Constructor.messageActionGeoChatCreate; }
		}

		public override void Write(BinaryWriter writer)
		{
			writer.Write(0x6f038ebc);
			Serializers.String.write(writer, this.title);
			Serializers.String.write(writer, this.address);
		}

		public override void Read(BinaryReader reader)
		{
			this.title = Serializers.String.read(reader);
			this.address = Serializers.String.read(reader);
		}

		public override string ToString()
		{
			return String.Format("(messageActionGeoChatCreate title:'{0}' address:'{1}')", title, address);
		}
	}


	public class MessageActionGeoChatCheckinConstructor : MessageAction
	{

		public MessageActionGeoChatCheckinConstructor()
		{

		}



		public Constructor Constructor
		{
			get { return Constructor.messageActionGeoChatCheckin; }
		}

		public override void Write(BinaryWriter writer)
		{
			writer.Write(0x0c7d53de);
		}

		public override void Read(BinaryReader reader)
		{
		}

		public override string ToString()
		{
			return String.Format("(messageActionGeoChatCheckin)");
		}
	}


	public class UpdateNewGeoChatMessageConstructor : Update
	{
		public GeoChatMessage message;

		public UpdateNewGeoChatMessageConstructor()
		{

		}

		public UpdateNewGeoChatMessageConstructor(GeoChatMessage message)
		{
			this.message = message;
		}


		public Constructor Constructor
		{
			get { return Constructor.updateNewGeoChatMessage; }
		}

		public override void Write(BinaryWriter writer)
		{
			writer.Write(0x5a68e3f7);
			this.message.Write(writer);
		}

		public override void Read(BinaryReader reader)
		{
			this.message = TL.Parse<GeoChatMessage>(reader);
		}

		public override string ToString()
		{
			return String.Format("(updateNewGeoChatMessage message:{0})", message);
		}
	}


	public class WallPaperSolidConstructor : WallPaper
	{
		public int id;
		public string title;
		public int bg_color;
		public int color;

		public WallPaperSolidConstructor()
		{

		}

		public WallPaperSolidConstructor(int id, string title, int bg_color, int color)
		{
			this.id = id;
			this.title = title;
			this.bg_color = bg_color;
			this.color = color;
		}


		public Constructor Constructor
		{
			get { return Constructor.wallPaperSolid; }
		}

		public override void Write(BinaryWriter writer)
		{
			writer.Write(0x63117f24);
			writer.Write(this.id);
			Serializers.String.write(writer, this.title);
			writer.Write(this.bg_color);
			writer.Write(this.color);
		}

		public override void Read(BinaryReader reader)
		{
			this.id = reader.ReadInt32();
			this.title = Serializers.String.read(reader);
			this.bg_color = reader.ReadInt32();
			this.color = reader.ReadInt32();
		}

		public override string ToString()
		{
			return String.Format("(wallPaperSolid id:{0} title:'{1}' bg_color:{2} color:{3})", id, title, bg_color, color);
		}
	}


	public class UpdateNewEncryptedMessageConstructor : Update
	{
		public EncryptedMessage message;
		public int qts;

		public UpdateNewEncryptedMessageConstructor()
		{

		}

		public UpdateNewEncryptedMessageConstructor(EncryptedMessage message, int qts)
		{
			this.message = message;
			this.qts = qts;
		}


		public Constructor Constructor
		{
			get { return Constructor.updateNewEncryptedMessage; }
		}

		public override void Write(BinaryWriter writer)
		{
			writer.Write(0x12bcbd9a);
			this.message.Write(writer);
			writer.Write(this.qts);
		}

		public override void Read(BinaryReader reader)
		{
			this.message = TL.Parse<EncryptedMessage>(reader);
			this.qts = reader.ReadInt32();
		}

		public override string ToString()
		{
			return String.Format("(updateNewEncryptedMessage message:{0} qts:{1})", message, qts);
		}
	}


	public class UpdateEncryptedChatTypingConstructor : Update
	{
		public int chat_id;

		public UpdateEncryptedChatTypingConstructor()
		{

		}

		public UpdateEncryptedChatTypingConstructor(int chat_id)
		{
			this.chat_id = chat_id;
		}


		public Constructor Constructor
		{
			get { return Constructor.updateEncryptedChatTyping; }
		}

		public override void Write(BinaryWriter writer)
		{
			writer.Write(0x1710f156);
			writer.Write(this.chat_id);
		}

		public override void Read(BinaryReader reader)
		{
			this.chat_id = reader.ReadInt32();
		}

		public override string ToString()
		{
			return String.Format("(updateEncryptedChatTyping chat_id:{0})", chat_id);
		}
	}


	public class UpdateEncryptionConstructor : Update
	{
		public EncryptedChat chat;
		public int date;

		public UpdateEncryptionConstructor()
		{

		}

		public UpdateEncryptionConstructor(EncryptedChat chat, int date)
		{
			this.chat = chat;
			this.date = date;
		}


		public Constructor Constructor
		{
			get { return Constructor.updateEncryption; }
		}

		public override void Write(BinaryWriter writer)
		{
			writer.Write(0xb4a2e88d);
			this.chat.Write(writer);
			writer.Write(this.date);
		}

		public override void Read(BinaryReader reader)
		{
			this.chat = TL.Parse<EncryptedChat>(reader);
			this.date = reader.ReadInt32();
		}

		public override string ToString()
		{
			return String.Format("(updateEncryption chat:{0} date:{1})", chat, date);
		}
	}


	public class UpdateEncryptedMessagesReadConstructor : Update
	{
		public int chat_id;
		public int max_date;
		public int date;

		public UpdateEncryptedMessagesReadConstructor()
		{

		}

		public UpdateEncryptedMessagesReadConstructor(int chat_id, int max_date, int date)
		{
			this.chat_id = chat_id;
			this.max_date = max_date;
			this.date = date;
		}


		public Constructor Constructor
		{
			get { return Constructor.updateEncryptedMessagesRead; }
		}

		public override void Write(BinaryWriter writer)
		{
			writer.Write(0x38fe25b7);
			writer.Write(this.chat_id);
			writer.Write(this.max_date);
			writer.Write(this.date);
		}

		public override void Read(BinaryReader reader)
		{
			this.chat_id = reader.ReadInt32();
			this.max_date = reader.ReadInt32();
			this.date = reader.ReadInt32();
		}

		public override string ToString()
		{
			return String.Format("(updateEncryptedMessagesRead chat_id:{0} max_date:{1} date:{2})", chat_id, max_date, date);
		}
	}


	public class EncryptedChatEmptyConstructor : EncryptedChat
	{
		public int id;

		public EncryptedChatEmptyConstructor()
		{

		}

		public EncryptedChatEmptyConstructor(int id)
		{
			this.id = id;
		}


		public Constructor Constructor
		{
			get { return Constructor.encryptedChatEmpty; }
		}

		public override void Write(BinaryWriter writer)
		{
			writer.Write(0xab7ec0a0);
			writer.Write(this.id);
		}

		public override void Read(BinaryReader reader)
		{
			this.id = reader.ReadInt32();
		}

		public override string ToString()
		{
			return String.Format("(encryptedChatEmpty id:{0})", id);
		}
	}


	public class EncryptedChatWaitingConstructor : EncryptedChat
	{
		public int id;
		public long access_hash;
		public int date;
		public int admin_id;
		public int participant_id;

		public EncryptedChatWaitingConstructor()
		{

		}

		public EncryptedChatWaitingConstructor(int id, long access_hash, int date, int admin_id, int participant_id)
		{
			this.id = id;
			this.access_hash = access_hash;
			this.date = date;
			this.admin_id = admin_id;
			this.participant_id = participant_id;
		}


		public Constructor Constructor
		{
			get { return Constructor.encryptedChatWaiting; }
		}

		public override void Write(BinaryWriter writer)
		{
			writer.Write(0x3bf703dc);
			writer.Write(this.id);
			writer.Write(this.access_hash);
			writer.Write(this.date);
			writer.Write(this.admin_id);
			writer.Write(this.participant_id);
		}

		public override void Read(BinaryReader reader)
		{
			this.id = reader.ReadInt32();
			this.access_hash = reader.ReadInt64();
			this.date = reader.ReadInt32();
			this.admin_id = reader.ReadInt32();
			this.participant_id = reader.ReadInt32();
		}

		public override string ToString()
		{
			return String.Format("(encryptedChatWaiting id:{0} access_hash:{1} date:{2} admin_id:{3} participant_id:{4})", id,
				access_hash, date, admin_id, participant_id);
		}
	}


	public class EncryptedChatRequestedConstructor : EncryptedChat
	{
		public int id;
		public long access_hash;
		public int date;
		public int admin_id;
		public int participant_id;
		public byte[] g_a;
		public byte[] nonce;

		public EncryptedChatRequestedConstructor()
		{

		}

		public EncryptedChatRequestedConstructor(int id, long access_hash, int date, int admin_id, int participant_id,
			byte[] g_a, byte[] nonce)
		{
			this.id = id;
			this.access_hash = access_hash;
			this.date = date;
			this.admin_id = admin_id;
			this.participant_id = participant_id;
			this.g_a = g_a;
			this.nonce = nonce;
		}


		public Constructor Constructor
		{
			get { return Constructor.encryptedChatRequested; }
		}

		public override void Write(BinaryWriter writer)
		{
			writer.Write(0xfda9a7b7);
			writer.Write(this.id);
			writer.Write(this.access_hash);
			writer.Write(this.date);
			writer.Write(this.admin_id);
			writer.Write(this.participant_id);
			Serializers.Bytes.write(writer, this.g_a);
			Serializers.Bytes.write(writer, this.nonce);
		}

		public override void Read(BinaryReader reader)
		{
			this.id = reader.ReadInt32();
			this.access_hash = reader.ReadInt64();
			this.date = reader.ReadInt32();
			this.admin_id = reader.ReadInt32();
			this.participant_id = reader.ReadInt32();
			this.g_a = Serializers.Bytes.read(reader);
			this.nonce = Serializers.Bytes.read(reader);
		}

		public override string ToString()
		{
			return
				String.Format(
					"(encryptedChatRequested id:{0} access_hash:{1} date:{2} admin_id:{3} participant_id:{4} g_a:{5} nonce:{6})", id,
					access_hash, date, admin_id, participant_id, BitConverter.ToString(g_a), BitConverter.ToString(nonce));
		}
	}


	public class EncryptedChatConstructor : EncryptedChat
	{
		public int id;
		public long access_hash;
		public int date;
		public int admin_id;
		public int participant_id;
		public byte[] g_a_or_b;
		public byte[] nonce;
		public long key_fingerprint;

		public EncryptedChatConstructor()
		{

		}

		public EncryptedChatConstructor(int id, long access_hash, int date, int admin_id, int participant_id, byte[] g_a_or_b,
			byte[] nonce, long key_fingerprint)
		{
			this.id = id;
			this.access_hash = access_hash;
			this.date = date;
			this.admin_id = admin_id;
			this.participant_id = participant_id;
			this.g_a_or_b = g_a_or_b;
			this.nonce = nonce;
			this.key_fingerprint = key_fingerprint;
		}


		public Constructor Constructor
		{
			get { return Constructor.encryptedChat; }
		}

		public override void Write(BinaryWriter writer)
		{
			writer.Write(0x6601d14f);
			writer.Write(this.id);
			writer.Write(this.access_hash);
			writer.Write(this.date);
			writer.Write(this.admin_id);
			writer.Write(this.participant_id);
			Serializers.Bytes.write(writer, this.g_a_or_b);
			Serializers.Bytes.write(writer, this.nonce);
			writer.Write(this.key_fingerprint);
		}

		public override void Read(BinaryReader reader)
		{
			this.id = reader.ReadInt32();
			this.access_hash = reader.ReadInt64();
			this.date = reader.ReadInt32();
			this.admin_id = reader.ReadInt32();
			this.participant_id = reader.ReadInt32();
			this.g_a_or_b = Serializers.Bytes.read(reader);
			this.nonce = Serializers.Bytes.read(reader);
			this.key_fingerprint = reader.ReadInt64();
		}

		public override string ToString()
		{
			return
				String.Format(
					"(encryptedChat id:{0} access_hash:{1} date:{2} admin_id:{3} participant_id:{4} g_a_or_b:{5} nonce:{6} key_fingerprint:{7})",
					id, access_hash, date, admin_id, participant_id, BitConverter.ToString(g_a_or_b), BitConverter.ToString(nonce),
					key_fingerprint);
		}
	}


	public class EncryptedChatDiscardedConstructor : EncryptedChat
	{
		public int id;

		public EncryptedChatDiscardedConstructor()
		{

		}

		public EncryptedChatDiscardedConstructor(int id)
		{
			this.id = id;
		}


		public Constructor Constructor
		{
			get { return Constructor.encryptedChatDiscarded; }
		}

		public override void Write(BinaryWriter writer)
		{
			writer.Write(0x13d6dd27);
			writer.Write(this.id);
		}

		public override void Read(BinaryReader reader)
		{
			this.id = reader.ReadInt32();
		}

		public override string ToString()
		{
			return String.Format("(encryptedChatDiscarded id:{0})", id);
		}
	}


	public class InputEncryptedChatConstructor : InputEncryptedChat
	{
		public int chat_id;
		public long access_hash;

		public InputEncryptedChatConstructor()
		{

		}

		public InputEncryptedChatConstructor(int chat_id, long access_hash)
		{
			this.chat_id = chat_id;
			this.access_hash = access_hash;
		}


		public Constructor Constructor
		{
			get { return Constructor.inputEncryptedChat; }
		}

		public override void Write(BinaryWriter writer)
		{
			writer.Write(0xf141b5e1);
			writer.Write(this.chat_id);
			writer.Write(this.access_hash);
		}

		public override void Read(BinaryReader reader)
		{
			this.chat_id = reader.ReadInt32();
			this.access_hash = reader.ReadInt64();
		}

		public override string ToString()
		{
			return String.Format("(inputEncryptedChat chat_id:{0} access_hash:{1})", chat_id, access_hash);
		}
	}


	public class EncryptedFileEmptyConstructor : EncryptedFile
	{

		public EncryptedFileEmptyConstructor()
		{

		}



		public Constructor Constructor
		{
			get { return Constructor.encryptedFileEmpty; }
		}

		public override void Write(BinaryWriter writer)
		{
			writer.Write(0xc21f497e);
		}

		public override void Read(BinaryReader reader)
		{
		}

		public override string ToString()
		{
			return String.Format("(encryptedFileEmpty)");
		}
	}


	public class EncryptedFileConstructor : EncryptedFile
	{
		public long id;
		public long access_hash;
		public int size;
		public int dc_id;
		public int key_fingerprint;

		public EncryptedFileConstructor()
		{

		}

		public EncryptedFileConstructor(long id, long access_hash, int size, int dc_id, int key_fingerprint)
		{
			this.id = id;
			this.access_hash = access_hash;
			this.size = size;
			this.dc_id = dc_id;
			this.key_fingerprint = key_fingerprint;
		}


		public Constructor Constructor
		{
			get { return Constructor.encryptedFile; }
		}

		public override void Write(BinaryWriter writer)
		{
			writer.Write(0x4a70994c);
			writer.Write(this.id);
			writer.Write(this.access_hash);
			writer.Write(this.size);
			writer.Write(this.dc_id);
			writer.Write(this.key_fingerprint);
		}

		public override void Read(BinaryReader reader)
		{
			this.id = reader.ReadInt64();
			this.access_hash = reader.ReadInt64();
			this.size = reader.ReadInt32();
			this.dc_id = reader.ReadInt32();
			this.key_fingerprint = reader.ReadInt32();
		}

		public override string ToString()
		{
			return String.Format("(encryptedFile id:{0} access_hash:{1} size:{2} dc_id:{3} key_fingerprint:{4})", id, access_hash,
				size, dc_id, key_fingerprint);
		}
	}


	public class InputEncryptedFileEmptyConstructor : InputEncryptedFile
	{

		public InputEncryptedFileEmptyConstructor()
		{

		}



		public Constructor Constructor
		{
			get { return Constructor.inputEncryptedFileEmpty; }
		}

		public override void Write(BinaryWriter writer)
		{
			writer.Write(0x1837c364);
		}

		public override void Read(BinaryReader reader)
		{
		}

		public override string ToString()
		{
			return String.Format("(inputEncryptedFileEmpty)");
		}
	}


	public class InputEncryptedFileUploadedConstructor : InputEncryptedFile
	{
		public long id;
		public int parts;
		public string md5_checksum;
		public int key_fingerprint;

		public InputEncryptedFileUploadedConstructor()
		{

		}

		public InputEncryptedFileUploadedConstructor(long id, int parts, string md5_checksum, int key_fingerprint)
		{
			this.id = id;
			this.parts = parts;
			this.md5_checksum = md5_checksum;
			this.key_fingerprint = key_fingerprint;
		}


		public Constructor Constructor
		{
			get { return Constructor.inputEncryptedFileUploaded; }
		}

		public override void Write(BinaryWriter writer)
		{
			writer.Write(0x64bd0306);
			writer.Write(this.id);
			writer.Write(this.parts);
			Serializers.String.write(writer, this.md5_checksum);
			writer.Write(this.key_fingerprint);
		}

		public override void Read(BinaryReader reader)
		{
			this.id = reader.ReadInt64();
			this.parts = reader.ReadInt32();
			this.md5_checksum = Serializers.String.read(reader);
			this.key_fingerprint = reader.ReadInt32();
		}

		public override string ToString()
		{
			return String.Format("(inputEncryptedFileUploaded id:{0} parts:{1} md5_checksum:'{2}' key_fingerprint:{3})", id,
				parts, md5_checksum, key_fingerprint);
		}
	}


	public class InputEncryptedFileConstructor : InputEncryptedFile
	{
		public long id;
		public long access_hash;

		public InputEncryptedFileConstructor()
		{

		}

		public InputEncryptedFileConstructor(long id, long access_hash)
		{
			this.id = id;
			this.access_hash = access_hash;
		}


		public Constructor Constructor
		{
			get { return Constructor.inputEncryptedFile; }
		}

		public override void Write(BinaryWriter writer)
		{
			writer.Write(0x5a17b5e5);
			writer.Write(this.id);
			writer.Write(this.access_hash);
		}

		public override void Read(BinaryReader reader)
		{
			this.id = reader.ReadInt64();
			this.access_hash = reader.ReadInt64();
		}

		public override string ToString()
		{
			return String.Format("(inputEncryptedFile id:{0} access_hash:{1})", id, access_hash);
		}
	}


	public class InputEncryptedFileLocationConstructor : InputFileLocation
	{
		public long id;
		public long access_hash;

		public InputEncryptedFileLocationConstructor()
		{

		}

		public InputEncryptedFileLocationConstructor(long id, long access_hash)
		{
			this.id = id;
			this.access_hash = access_hash;
		}


		public Constructor Constructor
		{
			get { return Constructor.inputEncryptedFileLocation; }
		}

		public override void Write(BinaryWriter writer)
		{
			writer.Write(0xf5235d55);
			writer.Write(this.id);
			writer.Write(this.access_hash);
		}

		public override void Read(BinaryReader reader)
		{
			this.id = reader.ReadInt64();
			this.access_hash = reader.ReadInt64();
		}

		public override string ToString()
		{
			return String.Format("(inputEncryptedFileLocation id:{0} access_hash:{1})", id, access_hash);
		}
	}


	public class EncryptedMessageConstructor : EncryptedMessage
	{
		public long random_id;
		public int chat_id;
		public int date;
		public byte[] bytes;
		public EncryptedFile file;

		public EncryptedMessageConstructor()
		{

		}

		public EncryptedMessageConstructor(long random_id, int chat_id, int date, byte[] bytes, EncryptedFile file)
		{
			this.random_id = random_id;
			this.chat_id = chat_id;
			this.date = date;
			this.bytes = bytes;
			this.file = file;
		}


		public Constructor Constructor
		{
			get { return Constructor.encryptedMessage; }
		}

		public override void Write(BinaryWriter writer)
		{
			writer.Write(0xed18c118);
			writer.Write(this.random_id);
			writer.Write(this.chat_id);
			writer.Write(this.date);
			Serializers.Bytes.write(writer, this.bytes);
			this.file.Write(writer);
		}

		public override void Read(BinaryReader reader)
		{
			this.random_id = reader.ReadInt64();
			this.chat_id = reader.ReadInt32();
			this.date = reader.ReadInt32();
			this.bytes = Serializers.Bytes.read(reader);
			this.file = TL.Parse<EncryptedFile>(reader);
		}

		public override string ToString()
		{
			return String.Format("(encryptedMessage random_id:{0} chat_id:{1} date:{2} bytes:{3} file:{4})", random_id, chat_id,
				date, BitConverter.ToString(bytes), file);
		}
	}


	public class EncryptedMessageServiceConstructor : EncryptedMessage
	{
		public long random_id;
		public int chat_id;
		public int date;
		public byte[] bytes;

		public EncryptedMessageServiceConstructor()
		{

		}

		public EncryptedMessageServiceConstructor(long random_id, int chat_id, int date, byte[] bytes)
		{
			this.random_id = random_id;
			this.chat_id = chat_id;
			this.date = date;
			this.bytes = bytes;
		}


		public Constructor Constructor
		{
			get { return Constructor.encryptedMessageService; }
		}

		public override void Write(BinaryWriter writer)
		{
			writer.Write(0x23734b06);
			writer.Write(this.random_id);
			writer.Write(this.chat_id);
			writer.Write(this.date);
			Serializers.Bytes.write(writer, this.bytes);
		}

		public override void Read(BinaryReader reader)
		{
			this.random_id = reader.ReadInt64();
			this.chat_id = reader.ReadInt32();
			this.date = reader.ReadInt32();
			this.bytes = Serializers.Bytes.read(reader);
		}

		public override string ToString()
		{
			return String.Format("(encryptedMessageService random_id:{0} chat_id:{1} date:{2} bytes:{3})", random_id, chat_id,
				date, BitConverter.ToString(bytes));
		}
	}


	public class DecryptedMessageLayerConstructor : DecryptedMessageLayer
	{
		public int layer;
		public DecryptedMessage message;

		public DecryptedMessageLayerConstructor()
		{

		}

		public DecryptedMessageLayerConstructor(int layer, DecryptedMessage message)
		{
			this.layer = layer;
			this.message = message;
		}


		public Constructor Constructor
		{
			get { return Constructor.decryptedMessageLayer; }
		}

		public override void Write(BinaryWriter writer)
		{
			writer.Write(0x99a438cf);
			writer.Write(this.layer);
			this.message.Write(writer);
		}

		public override void Read(BinaryReader reader)
		{
			this.layer = reader.ReadInt32();
			this.message = TL.Parse<DecryptedMessage>(reader);
		}

		public override string ToString()
		{
			return String.Format("(decryptedMessageLayer layer:{0} message:{1})", layer, message);
		}
	}


	public class DecryptedMessageConstructor : DecryptedMessage
	{
		public long random_id;
		public byte[] random_bytes;
		public string message;
		public DecryptedMessageMedia media;

		public DecryptedMessageConstructor()
		{

		}

		public DecryptedMessageConstructor(long random_id, byte[] random_bytes, string message, DecryptedMessageMedia media)
		{
			this.random_id = random_id;
			this.random_bytes = random_bytes;
			this.message = message;
			this.media = media;
		}


		public Constructor Constructor
		{
			get { return Constructor.decryptedMessage; }
		}

		public override void Write(BinaryWriter writer)
		{
			writer.Write(0x1f814f1f);
			writer.Write(this.random_id);
			Serializers.Bytes.write(writer, this.random_bytes);
			Serializers.String.write(writer, this.message);
			this.media.Write(writer);
		}

		public override void Read(BinaryReader reader)
		{
			this.random_id = reader.ReadInt64();
			this.random_bytes = Serializers.Bytes.read(reader);
			this.message = Serializers.String.read(reader);
			this.media = TL.Parse<DecryptedMessageMedia>(reader);
		}

		public override string ToString()
		{
			return String.Format("(decryptedMessage random_id:{0} random_bytes:{1} message:'{2}' media:{3})", random_id,
				BitConverter.ToString(random_bytes), message, media);
		}
	}


	public class DecryptedMessageServiceConstructor : DecryptedMessage
	{
		public long random_id;
		public byte[] random_bytes;
		public DecryptedMessageAction action;

		public DecryptedMessageServiceConstructor()
		{

		}

		public DecryptedMessageServiceConstructor(long random_id, byte[] random_bytes, DecryptedMessageAction action)
		{
			this.random_id = random_id;
			this.random_bytes = random_bytes;
			this.action = action;
		}


		public Constructor Constructor
		{
			get { return Constructor.decryptedMessageService; }
		}

		public override void Write(BinaryWriter writer)
		{
			writer.Write(0xaa48327d);
			writer.Write(this.random_id);
			Serializers.Bytes.write(writer, this.random_bytes);
			this.action.Write(writer);
		}

		public override void Read(BinaryReader reader)
		{
			this.random_id = reader.ReadInt64();
			this.random_bytes = Serializers.Bytes.read(reader);
			this.action = TL.Parse<DecryptedMessageAction>(reader);
		}

		public override string ToString()
		{
			return String.Format("(decryptedMessageService random_id:{0} random_bytes:{1} action:{2})", random_id,
				BitConverter.ToString(random_bytes), action);
		}
	}


	public class DecryptedMessageMediaEmptyConstructor : DecryptedMessageMedia
	{

		public DecryptedMessageMediaEmptyConstructor()
		{

		}



		public Constructor Constructor
		{
			get { return Constructor.decryptedMessageMediaEmpty; }
		}

		public override void Write(BinaryWriter writer)
		{
			writer.Write(0x089f5c4a);
		}

		public override void Read(BinaryReader reader)
		{
		}

		public override string ToString()
		{
			return String.Format("(decryptedMessageMediaEmpty)");
		}
	}


	public class DecryptedMessageMediaPhotoConstructor : DecryptedMessageMedia
	{
		public byte[] thumb;
		public int thumb_w;
		public int thumb_h;
		public int w;
		public int h;
		public int size;
		public byte[] key;
		public byte[] iv;

		public DecryptedMessageMediaPhotoConstructor()
		{

		}

		public DecryptedMessageMediaPhotoConstructor(byte[] thumb, int thumb_w, int thumb_h, int w, int h, int size,
			byte[] key, byte[] iv)
		{
			this.thumb = thumb;
			this.thumb_w = thumb_w;
			this.thumb_h = thumb_h;
			this.w = w;
			this.h = h;
			this.size = size;
			this.key = key;
			this.iv = iv;
		}


		public Constructor Constructor
		{
			get { return Constructor.decryptedMessageMediaPhoto; }
		}

		public override void Write(BinaryWriter writer)
		{
			writer.Write(0x32798a8c);
			Serializers.Bytes.write(writer, this.thumb);
			writer.Write(this.thumb_w);
			writer.Write(this.thumb_h);
			writer.Write(this.w);
			writer.Write(this.h);
			writer.Write(this.size);
			Serializers.Bytes.write(writer, this.key);
			Serializers.Bytes.write(writer, this.iv);
		}

		public override void Read(BinaryReader reader)
		{
			this.thumb = Serializers.Bytes.read(reader);
			this.thumb_w = reader.ReadInt32();
			this.thumb_h = reader.ReadInt32();
			this.w = reader.ReadInt32();
			this.h = reader.ReadInt32();
			this.size = reader.ReadInt32();
			this.key = Serializers.Bytes.read(reader);
			this.iv = Serializers.Bytes.read(reader);
		}

		public override string ToString()
		{
			return
				String.Format("(decryptedMessageMediaPhoto thumb:{0} thumb_w:{1} thumb_h:{2} w:{3} h:{4} size:{5} key:{6} iv:{7})",
					BitConverter.ToString(thumb), thumb_w, thumb_h, w, h, size, BitConverter.ToString(key), BitConverter.ToString(iv));
		}
	}


	public class DecryptedMessageMediaVideoConstructor : DecryptedMessageMedia
	{
		public byte[] thumb;
		public int thumb_w;
		public int thumb_h;
		public int duration;
		public int w;
		public int h;
		public int size;
		public byte[] key;
		public byte[] iv;

		public DecryptedMessageMediaVideoConstructor()
		{

		}

		public DecryptedMessageMediaVideoConstructor(byte[] thumb, int thumb_w, int thumb_h, int duration, int w, int h,
			int size, byte[] key, byte[] iv)
		{
			this.thumb = thumb;
			this.thumb_w = thumb_w;
			this.thumb_h = thumb_h;
			this.duration = duration;
			this.w = w;
			this.h = h;
			this.size = size;
			this.key = key;
			this.iv = iv;
		}


		public Constructor Constructor
		{
			get { return Constructor.decryptedMessageMediaVideo; }
		}

		public override void Write(BinaryWriter writer)
		{
			writer.Write(0x4cee6ef3);
			Serializers.Bytes.write(writer, this.thumb);
			writer.Write(this.thumb_w);
			writer.Write(this.thumb_h);
			writer.Write(this.duration);
			writer.Write(this.w);
			writer.Write(this.h);
			writer.Write(this.size);
			Serializers.Bytes.write(writer, this.key);
			Serializers.Bytes.write(writer, this.iv);
		}

		public override void Read(BinaryReader reader)
		{
			this.thumb = Serializers.Bytes.read(reader);
			this.thumb_w = reader.ReadInt32();
			this.thumb_h = reader.ReadInt32();
			this.duration = reader.ReadInt32();
			this.w = reader.ReadInt32();
			this.h = reader.ReadInt32();
			this.size = reader.ReadInt32();
			this.key = Serializers.Bytes.read(reader);
			this.iv = Serializers.Bytes.read(reader);
		}

		public override string ToString()
		{
			return
				String.Format(
					"(decryptedMessageMediaVideo thumb:{0} thumb_w:{1} thumb_h:{2} duration:{3} w:{4} h:{5} size:{6} key:{7} iv:{8})",
					BitConverter.ToString(thumb), thumb_w, thumb_h, duration, w, h, size, BitConverter.ToString(key),
					BitConverter.ToString(iv));
		}
	}


	public class DecryptedMessageMediaGeoPointConstructor : DecryptedMessageMedia
	{
		public double lat;
		public double lng;

		public DecryptedMessageMediaGeoPointConstructor()
		{

		}

		public DecryptedMessageMediaGeoPointConstructor(double lat, double lng)
		{
			this.lat = lat;
			this.lng = lng;
		}


		public Constructor Constructor
		{
			get { return Constructor.decryptedMessageMediaGeoPoint; }
		}

		public override void Write(BinaryWriter writer)
		{
			writer.Write(0x35480a59);
			writer.Write(this.lat);
			writer.Write(this.lng);
		}

		public override void Read(BinaryReader reader)
		{
			this.lat = reader.ReadDouble();
			this.lng = reader.ReadDouble();
		}

		public override string ToString()
		{
			return String.Format("(decryptedMessageMediaGeoPoint lat:{0} long:{1})", lat, lng);
		}
	}


	public class DecryptedMessageMediaContactConstructor : DecryptedMessageMedia
	{
		public string phone_number;
		public string first_name;
		public string last_name;
		public int user_id;

		public DecryptedMessageMediaContactConstructor()
		{

		}

		public DecryptedMessageMediaContactConstructor(string phone_number, string first_name, string last_name, int user_id)
		{
			this.phone_number = phone_number;
			this.first_name = first_name;
			this.last_name = last_name;
			this.user_id = user_id;
		}


		public Constructor Constructor
		{
			get { return Constructor.decryptedMessageMediaContact; }
		}

		public override void Write(BinaryWriter writer)
		{
			writer.Write(0x588a0a97);
			Serializers.String.write(writer, this.phone_number);
			Serializers.String.write(writer, this.first_name);
			Serializers.String.write(writer, this.last_name);
			writer.Write(this.user_id);
		}

		public override void Read(BinaryReader reader)
		{
			this.phone_number = Serializers.String.read(reader);
			this.first_name = Serializers.String.read(reader);
			this.last_name = Serializers.String.read(reader);
			this.user_id = reader.ReadInt32();
		}

		public override string ToString()
		{
			return String.Format(
				"(decryptedMessageMediaContact phone_number:'{0}' first_name:'{1}' last_name:'{2}' user_id:{3})", phone_number,
				first_name, last_name, user_id);
		}
	}


	public class DecryptedMessageActionSetMessageTTLConstructor : DecryptedMessageAction
	{
		public int ttl_seconds;

		public DecryptedMessageActionSetMessageTTLConstructor()
		{

		}

		public DecryptedMessageActionSetMessageTTLConstructor(int ttl_seconds)
		{
			this.ttl_seconds = ttl_seconds;
		}


		public Constructor Constructor
		{
			get { return Constructor.decryptedMessageActionSetMessageTTL; }
		}

		public override void Write(BinaryWriter writer)
		{
			writer.Write(0xa1733aec);
			writer.Write(this.ttl_seconds);
		}

		public override void Read(BinaryReader reader)
		{
			this.ttl_seconds = reader.ReadInt32();
		}

		public override string ToString()
		{
			return String.Format("(decryptedMessageActionSetMessageTTL ttl_seconds:{0})", ttl_seconds);
		}
	}


	public class Messages_dhConfigNotModifiedConstructor : messages_DhConfig
	{
		public byte[] random;

		public Messages_dhConfigNotModifiedConstructor()
		{

		}

		public Messages_dhConfigNotModifiedConstructor(byte[] random)
		{
			this.random = random;
		}


		public Constructor Constructor
		{
			get { return Constructor.messages_dhConfigNotModified; }
		}

		public override void Write(BinaryWriter writer)
		{
			writer.Write(0xc0e24635);
			Serializers.Bytes.write(writer, this.random);
		}

		public override void Read(BinaryReader reader)
		{
			this.random = Serializers.Bytes.read(reader);
		}

		public override string ToString()
		{
			return String.Format("(messages_dhConfigNotModified random:{0})", BitConverter.ToString(random));
		}
	}


	public class Messages_dhConfigConstructor : messages_DhConfig
	{
		public int g;
		public byte[] p;
		public int version;
		public byte[] random;

		public Messages_dhConfigConstructor()
		{

		}

		public Messages_dhConfigConstructor(int g, byte[] p, int version, byte[] random)
		{
			this.g = g;
			this.p = p;
			this.version = version;
			this.random = random;
		}


		public Constructor Constructor
		{
			get { return Constructor.messages_dhConfig; }
		}

		public override void Write(BinaryWriter writer)
		{
			writer.Write(0x2c221edd);
			writer.Write(this.g);
			Serializers.Bytes.write(writer, this.p);
			writer.Write(this.version);
			Serializers.Bytes.write(writer, this.random);
		}

		public override void Read(BinaryReader reader)
		{
			this.g = reader.ReadInt32();
			this.p = Serializers.Bytes.read(reader);
			this.version = reader.ReadInt32();
			this.random = Serializers.Bytes.read(reader);
		}

		public override string ToString()
		{
			return String.Format("(messages_dhConfig g:{0} p:{1} version:{2} random:{3})", g, BitConverter.ToString(p), version,
				BitConverter.ToString(random));
		}
	}


	public class Messages_sentEncryptedMessageConstructor : messages_SentEncryptedMessage
	{
		public int date;

		public Messages_sentEncryptedMessageConstructor()
		{

		}

		public Messages_sentEncryptedMessageConstructor(int date)
		{
			this.date = date;
		}


		public Constructor Constructor
		{
			get { return Constructor.messages_sentEncryptedMessage; }
		}

		public override void Write(BinaryWriter writer)
		{
			writer.Write(0x560f8935);
			writer.Write(this.date);
		}

		public override void Read(BinaryReader reader)
		{
			this.date = reader.ReadInt32();
		}

		public override string ToString()
		{
			return String.Format("(messages_sentEncryptedMessage date:{0})", date);
		}
	}


	public class Messages_sentEncryptedFileConstructor : messages_SentEncryptedMessage
	{
		public int date;
		public EncryptedFile file;

		public Messages_sentEncryptedFileConstructor()
		{

		}

		public Messages_sentEncryptedFileConstructor(int date, EncryptedFile file)
		{
			this.date = date;
			this.file = file;
		}


		public Constructor Constructor
		{
			get { return Constructor.messages_sentEncryptedFile; }
		}

		public override void Write(BinaryWriter writer)
		{
			writer.Write(0x9493ff32);
			writer.Write(this.date);
			this.file.Write(writer);
		}

		public override void Read(BinaryReader reader)
		{
			this.date = reader.ReadInt32();
			this.file = TL.Parse<EncryptedFile>(reader);
		}

		public override string ToString()
		{
			return String.Format("(messages_sentEncryptedFile date:{0} file:{1})", date, file);
		}
	}


	public class InputFileBigConstructor : InputFile
	{
		public long id;
		public int parts;
		public string name;

		public InputFileBigConstructor()
		{

		}

		public InputFileBigConstructor(long id, int parts, string name)
		{
			this.id = id;
			this.parts = parts;
			this.name = name;
		}


		public Constructor Constructor
		{
			get { return Constructor.inputFileBig; }
		}

		public override void Write(BinaryWriter writer)
		{
			writer.Write(0xfa4f0bb5);
			writer.Write(this.id);
			writer.Write(this.parts);
			Serializers.String.write(writer, this.name);
		}

		public override void Read(BinaryReader reader)
		{
			this.id = reader.ReadInt64();
			this.parts = reader.ReadInt32();
			this.name = Serializers.String.read(reader);
		}

		public override string ToString()
		{
			return String.Format("(inputFileBig id:{0} parts:{1} name:'{2}')", id, parts, name);
		}
	}


	public class InputEncryptedFileBigUploadedConstructor : InputEncryptedFile
	{
		public long id;
		public int parts;
		public int key_fingerprint;

		public InputEncryptedFileBigUploadedConstructor()
		{

		}

		public InputEncryptedFileBigUploadedConstructor(long id, int parts, int key_fingerprint)
		{
			this.id = id;
			this.parts = parts;
			this.key_fingerprint = key_fingerprint;
		}


		public Constructor Constructor
		{
			get { return Constructor.inputEncryptedFileBigUploaded; }
		}

		public override void Write(BinaryWriter writer)
		{
			writer.Write(0x2dc173c8);
			writer.Write(this.id);
			writer.Write(this.parts);
			writer.Write(this.key_fingerprint);
		}

		public override void Read(BinaryReader reader)
		{
			this.id = reader.ReadInt64();
			this.parts = reader.ReadInt32();
			this.key_fingerprint = reader.ReadInt32();
		}

		public override string ToString()
		{
			return String.Format("(inputEncryptedFileBigUploaded id:{0} parts:{1} key_fingerprint:{2})", id, parts,
				key_fingerprint);
		}
	}


	public class UpdateChatParticipantAddConstructor : Update
	{
		public int chat_id;
		public int user_id;
		public int inviter_id;
		public int version;

		public UpdateChatParticipantAddConstructor()
		{

		}

		public UpdateChatParticipantAddConstructor(int chat_id, int user_id, int inviter_id, int version)
		{
			this.chat_id = chat_id;
			this.user_id = user_id;
			this.inviter_id = inviter_id;
			this.version = version;
		}


		public Constructor Constructor
		{
			get { return Constructor.updateChatParticipantAdd; }
		}

		public override void Write(BinaryWriter writer)
		{
			writer.Write(0x3a0eeb22);
			writer.Write(this.chat_id);
			writer.Write(this.user_id);
			writer.Write(this.inviter_id);
			writer.Write(this.version);
		}

		public override void Read(BinaryReader reader)
		{
			this.chat_id = reader.ReadInt32();
			this.user_id = reader.ReadInt32();
			this.inviter_id = reader.ReadInt32();
			this.version = reader.ReadInt32();
		}

		public override string ToString()
		{
			return String.Format("(updateChatParticipantAdd chat_id:{0} user_id:{1} inviter_id:{2} version:{3})", chat_id,
				user_id, inviter_id, version);
		}
	}


	public class UpdateChatParticipantDeleteConstructor : Update
	{
		public int chat_id;
		public int user_id;
		public int version;

		public UpdateChatParticipantDeleteConstructor()
		{

		}

		public UpdateChatParticipantDeleteConstructor(int chat_id, int user_id, int version)
		{
			this.chat_id = chat_id;
			this.user_id = user_id;
			this.version = version;
		}


		public Constructor Constructor
		{
			get { return Constructor.updateChatParticipantDelete; }
		}

		public override void Write(BinaryWriter writer)
		{
			writer.Write(0x6e5f8c22);
			writer.Write(this.chat_id);
			writer.Write(this.user_id);
			writer.Write(this.version);
		}

		public override void Read(BinaryReader reader)
		{
			this.chat_id = reader.ReadInt32();
			this.user_id = reader.ReadInt32();
			this.version = reader.ReadInt32();
		}

		public override string ToString()
		{
			return String.Format("(updateChatParticipantDelete chat_id:{0} user_id:{1} version:{2})", chat_id, user_id, version);
		}
	}


	public class UpdateDcOptionsConstructor : Update
	{
		public List<DcOption> dc_options;

		public UpdateDcOptionsConstructor()
		{

		}

		public UpdateDcOptionsConstructor(List<DcOption> dc_options)
		{
			this.dc_options = dc_options;
		}


		public Constructor Constructor
		{
			get { return Constructor.updateDcOptions; }
		}

		public override void Write(BinaryWriter writer)
		{
			writer.Write(0x8e5e9873);
			writer.Write(0x1cb5c415);
			writer.Write(this.dc_options.Count);
			foreach (DcOption dc_options_element in this.dc_options)
			{
				dc_options_element.Write(writer);
			}
		}

		public override void Read(BinaryReader reader)
		{
			reader.ReadInt32(); // vector code
			int dc_options_len = reader.ReadInt32();
			this.dc_options = new List<DcOption>(dc_options_len);
			for (int dc_options_index = 0; dc_options_index < dc_options_len; dc_options_index++)
			{
				DcOption dc_options_element;
				dc_options_element = TL.Parse<DcOption>(reader);
				this.dc_options.Add(dc_options_element);
			}
		}

		public override string ToString()
		{
			return String.Format("(updateDcOptions dc_options:{0})", Serializers.VectorToString(dc_options));
		}
	}


	public class InputMediaUploadedAudioConstructor : InputMedia
	{
		public InputFile file;
		public int duration;

		public InputMediaUploadedAudioConstructor()
		{

		}

		public InputMediaUploadedAudioConstructor(InputFile file, int duration)
		{
			this.file = file;
			this.duration = duration;
		}


		public Constructor Constructor
		{
			get { return Constructor.inputMediaUploadedAudio; }
		}

		public override void Write(BinaryWriter writer)
		{
			writer.Write(0x61a6d436);
			this.file.Write(writer);
			writer.Write(this.duration);
		}

		public override void Read(BinaryReader reader)
		{
			this.file = TL.Parse<InputFile>(reader);
			this.duration = reader.ReadInt32();
		}

		public override string ToString()
		{
			return String.Format("(inputMediaUploadedAudio file:{0} duration:{1})", file, duration);
		}
	}


	public class InputMediaAudioConstructor : InputMedia
	{
		public InputAudio id;

		public InputMediaAudioConstructor()
		{

		}

		public InputMediaAudioConstructor(InputAudio id)
		{
			this.id = id;
		}


		public Constructor Constructor
		{
			get { return Constructor.inputMediaAudio; }
		}

		public override void Write(BinaryWriter writer)
		{
			writer.Write(0x89938781);
			this.id.Write(writer);
		}

		public override void Read(BinaryReader reader)
		{
			this.id = TL.Parse<InputAudio>(reader);
		}

		public override string ToString()
		{
			return String.Format("(inputMediaAudio id:{0})", id);
		}
	}


	public class InputMediaUploadedDocumentConstructor : InputMedia
	{
		public InputFile file;
		public string file_name;
		public string mime_type;

		public InputMediaUploadedDocumentConstructor()
		{

		}

		public InputMediaUploadedDocumentConstructor(InputFile file, string file_name, string mime_type)
		{
			this.file = file;
			this.file_name = file_name;
			this.mime_type = mime_type;
		}


		public Constructor Constructor
		{
			get { return Constructor.inputMediaUploadedDocument; }
		}

		public override void Write(BinaryWriter writer)
		{
			writer.Write(0x34e794bd);
			this.file.Write(writer);
			Serializers.String.write(writer, this.file_name);
			Serializers.String.write(writer, this.mime_type);
		}

		public override void Read(BinaryReader reader)
		{
			this.file = TL.Parse<InputFile>(reader);
			this.file_name = Serializers.String.read(reader);
			this.mime_type = Serializers.String.read(reader);
		}

		public override string ToString()
		{
			return String.Format("(inputMediaUploadedDocument file:{0} file_name:'{1}' mime_type:'{2}')", file, file_name,
				mime_type);
		}
	}


	public class InputMediaUploadedThumbDocumentConstructor : InputMedia
	{
		public InputFile file;
		public InputFile thumb;
		public string file_name;
		public string mime_type;

		public InputMediaUploadedThumbDocumentConstructor()
		{

		}

		public InputMediaUploadedThumbDocumentConstructor(InputFile file, InputFile thumb, string file_name, string mime_type)
		{
			this.file = file;
			this.thumb = thumb;
			this.file_name = file_name;
			this.mime_type = mime_type;
		}


		public Constructor Constructor
		{
			get { return Constructor.inputMediaUploadedThumbDocument; }
		}

		public override void Write(BinaryWriter writer)
		{
			writer.Write(0x3e46de5d);
			this.file.Write(writer);
			this.thumb.Write(writer);
			Serializers.String.write(writer, this.file_name);
			Serializers.String.write(writer, this.mime_type);
		}

		public override void Read(BinaryReader reader)
		{
			this.file = TL.Parse<InputFile>(reader);
			this.thumb = TL.Parse<InputFile>(reader);
			this.file_name = Serializers.String.read(reader);
			this.mime_type = Serializers.String.read(reader);
		}

		public override string ToString()
		{
			return String.Format("(inputMediaUploadedThumbDocument file:{0} thumb:{1} file_name:'{2}' mime_type:'{3}')", file,
				thumb, file_name, mime_type);
		}
	}


	public class InputMediaDocumentConstructor : InputMedia
	{
		public InputDocument id;

		public InputMediaDocumentConstructor()
		{

		}

		public InputMediaDocumentConstructor(InputDocument id)
		{
			this.id = id;
		}


		public Constructor Constructor
		{
			get { return Constructor.inputMediaDocument; }
		}

		public override void Write(BinaryWriter writer)
		{
			writer.Write(0xd184e841);
			this.id.Write(writer);
		}

		public override void Read(BinaryReader reader)
		{
			this.id = TL.Parse<InputDocument>(reader);
		}

		public override string ToString()
		{
			return String.Format("(inputMediaDocument id:{0})", id);
		}
	}


	public class MessageMediaDocumentConstructor : MessageMedia
	{
		public Document document;

		public MessageMediaDocumentConstructor()
		{

		}

		public MessageMediaDocumentConstructor(Document document)
		{
			this.document = document;
		}


		public Constructor Constructor
		{
			get { return Constructor.messageMediaDocument; }
		}

		public override void Write(BinaryWriter writer)
		{
			writer.Write(0x2fda2204);
			this.document.Write(writer);
		}

		public override void Read(BinaryReader reader)
		{
			this.document = TL.Parse<Document>(reader);
		}

		public override string ToString()
		{
			return String.Format("(messageMediaDocument document:{0})", document);
		}
	}


	public class MessageMediaAudioConstructor : MessageMedia
	{
		public Audio audio;

		public MessageMediaAudioConstructor()
		{

		}

		public MessageMediaAudioConstructor(Audio audio)
		{
			this.audio = audio;
		}


		public Constructor Constructor
		{
			get { return Constructor.messageMediaAudio; }
		}

		public override void Write(BinaryWriter writer)
		{
			writer.Write(0xc6b68300);
			this.audio.Write(writer);
		}

		public override void Read(BinaryReader reader)
		{
			this.audio = TL.Parse<Audio>(reader);
		}

		public override string ToString()
		{
			return String.Format("(messageMediaAudio audio:{0})", audio);
		}
	}


	public class InputAudioEmptyConstructor : InputAudio
	{

		public InputAudioEmptyConstructor()
		{

		}



		public Constructor Constructor
		{
			get { return Constructor.inputAudioEmpty; }
		}

		public override void Write(BinaryWriter writer)
		{
			writer.Write(0xd95adc84);
		}

		public override void Read(BinaryReader reader)
		{
		}

		public override string ToString()
		{
			return String.Format("(inputAudioEmpty)");
		}
	}


	public class InputAudioConstructor : InputAudio
	{
		public long id;
		public long access_hash;

		public InputAudioConstructor()
		{

		}

		public InputAudioConstructor(long id, long access_hash)
		{
			this.id = id;
			this.access_hash = access_hash;
		}


		public Constructor Constructor
		{
			get { return Constructor.inputAudio; }
		}

		public override void Write(BinaryWriter writer)
		{
			writer.Write(0x77d440ff);
			writer.Write(this.id);
			writer.Write(this.access_hash);
		}

		public override void Read(BinaryReader reader)
		{
			this.id = reader.ReadInt64();
			this.access_hash = reader.ReadInt64();
		}

		public override string ToString()
		{
			return String.Format("(inputAudio id:{0} access_hash:{1})", id, access_hash);
		}
	}


	public class InputDocumentEmptyConstructor : InputDocument
	{

		public InputDocumentEmptyConstructor()
		{

		}



		public Constructor Constructor
		{
			get { return Constructor.inputDocumentEmpty; }
		}

		public override void Write(BinaryWriter writer)
		{
			writer.Write(0x72f0eaae);
		}

		public override void Read(BinaryReader reader)
		{
		}

		public override string ToString()
		{
			return String.Format("(inputDocumentEmpty)");
		}
	}


	public class InputDocumentConstructor : InputDocument
	{
		public long id;
		public long access_hash;

		public InputDocumentConstructor()
		{

		}

		public InputDocumentConstructor(long id, long access_hash)
		{
			this.id = id;
			this.access_hash = access_hash;
		}


		public Constructor Constructor
		{
			get { return Constructor.inputDocument; }
		}

		public override void Write(BinaryWriter writer)
		{
			writer.Write(0x18798952);
			writer.Write(this.id);
			writer.Write(this.access_hash);
		}

		public override void Read(BinaryReader reader)
		{
			this.id = reader.ReadInt64();
			this.access_hash = reader.ReadInt64();
		}

		public override string ToString()
		{
			return String.Format("(inputDocument id:{0} access_hash:{1})", id, access_hash);
		}
	}


	public class InputAudioFileLocationConstructor : InputFileLocation
	{
		public long id;
		public long access_hash;

		public InputAudioFileLocationConstructor()
		{

		}

		public InputAudioFileLocationConstructor(long id, long access_hash)
		{
			this.id = id;
			this.access_hash = access_hash;
		}


		public Constructor Constructor
		{
			get { return Constructor.inputAudioFileLocation; }
		}

		public override void Write(BinaryWriter writer)
		{
			writer.Write(0x74dc404d);
			writer.Write(this.id);
			writer.Write(this.access_hash);
		}

		public override void Read(BinaryReader reader)
		{
			this.id = reader.ReadInt64();
			this.access_hash = reader.ReadInt64();
		}

		public override string ToString()
		{
			return String.Format("(inputAudioFileLocation id:{0} access_hash:{1})", id, access_hash);
		}
	}


	public class InputDocumentFileLocationConstructor : InputFileLocation
	{
		public long id;
		public long access_hash;

		public InputDocumentFileLocationConstructor()
		{

		}

		public InputDocumentFileLocationConstructor(long id, long access_hash)
		{
			this.id = id;
			this.access_hash = access_hash;
		}


		public Constructor Constructor
		{
			get { return Constructor.inputDocumentFileLocation; }
		}

		public override void Write(BinaryWriter writer)
		{
			writer.Write(0x4e45abe9);
			writer.Write(this.id);
			writer.Write(this.access_hash);
		}

		public override void Read(BinaryReader reader)
		{
			this.id = reader.ReadInt64();
			this.access_hash = reader.ReadInt64();
		}

		public override string ToString()
		{
			return String.Format("(inputDocumentFileLocation id:{0} access_hash:{1})", id, access_hash);
		}
	}


	public class DecryptedMessageMediaDocumentConstructor : DecryptedMessageMedia
	{
		public byte[] thumb;
		public int thumb_w;
		public int thumb_h;
		public string file_name;
		public string mime_type;
		public int size;
		public byte[] key;
		public byte[] iv;

		public DecryptedMessageMediaDocumentConstructor()
		{

		}

		public DecryptedMessageMediaDocumentConstructor(byte[] thumb, int thumb_w, int thumb_h, string file_name,
			string mime_type, int size, byte[] key, byte[] iv)
		{
			this.thumb = thumb;
			this.thumb_w = thumb_w;
			this.thumb_h = thumb_h;
			this.file_name = file_name;
			this.mime_type = mime_type;
			this.size = size;
			this.key = key;
			this.iv = iv;
		}


		public Constructor Constructor
		{
			get { return Constructor.decryptedMessageMediaDocument; }
		}

		public override void Write(BinaryWriter writer)
		{
			writer.Write(0xb095434b);
			Serializers.Bytes.write(writer, this.thumb);
			writer.Write(this.thumb_w);
			writer.Write(this.thumb_h);
			Serializers.String.write(writer, this.file_name);
			Serializers.String.write(writer, this.mime_type);
			writer.Write(this.size);
			Serializers.Bytes.write(writer, this.key);
			Serializers.Bytes.write(writer, this.iv);
		}

		public override void Read(BinaryReader reader)
		{
			this.thumb = Serializers.Bytes.read(reader);
			this.thumb_w = reader.ReadInt32();
			this.thumb_h = reader.ReadInt32();
			this.file_name = Serializers.String.read(reader);
			this.mime_type = Serializers.String.read(reader);
			this.size = reader.ReadInt32();
			this.key = Serializers.Bytes.read(reader);
			this.iv = Serializers.Bytes.read(reader);
		}

		public override string ToString()
		{
			return
				String.Format(
					"(decryptedMessageMediaDocument thumb:{0} thumb_w:{1} thumb_h:{2} file_name:'{3}' mime_type:'{4}' size:{5} key:{6} iv:{7})",
					BitConverter.ToString(thumb), thumb_w, thumb_h, file_name, mime_type, size, BitConverter.ToString(key),
					BitConverter.ToString(iv));
		}
	}


	public class DecryptedMessageMediaAudioConstructor : DecryptedMessageMedia
	{
		public int duration;
		public int size;
		public byte[] key;
		public byte[] iv;

		public DecryptedMessageMediaAudioConstructor()
		{

		}

		public DecryptedMessageMediaAudioConstructor(int duration, int size, byte[] key, byte[] iv)
		{
			this.duration = duration;
			this.size = size;
			this.key = key;
			this.iv = iv;
		}


		public Constructor Constructor
		{
			get { return Constructor.decryptedMessageMediaAudio; }
		}

		public override void Write(BinaryWriter writer)
		{
			writer.Write(0x6080758f);
			writer.Write(this.duration);
			writer.Write(this.size);
			Serializers.Bytes.write(writer, this.key);
			Serializers.Bytes.write(writer, this.iv);
		}

		public override void Read(BinaryReader reader)
		{
			this.duration = reader.ReadInt32();
			this.size = reader.ReadInt32();
			this.key = Serializers.Bytes.read(reader);
			this.iv = Serializers.Bytes.read(reader);
		}

		public override string ToString()
		{
			return String.Format("(decryptedMessageMediaAudio duration:{0} size:{1} key:{2} iv:{3})", duration, size,
				BitConverter.ToString(key), BitConverter.ToString(iv));
		}
	}


	public class AudioEmptyConstructor : Audio
	{
		public long id;

		public AudioEmptyConstructor()
		{

		}

		public AudioEmptyConstructor(long id)
		{
			this.id = id;
		}


		public Constructor Constructor
		{
			get { return Constructor.audioEmpty; }
		}

		public override void Write(BinaryWriter writer)
		{
			writer.Write(0x586988d8);
			writer.Write(this.id);
		}

		public override void Read(BinaryReader reader)
		{
			this.id = reader.ReadInt64();
		}

		public override string ToString()
		{
			return String.Format("(audioEmpty id:{0})", id);
		}
	}


	public class AudioConstructor : Audio
	{
		public long id;
		public long access_hash;
		public int user_id;
		public int date;
		public int duration;
		public int size;
		public int dc_id;

		public AudioConstructor()
		{

		}

		public AudioConstructor(long id, long access_hash, int user_id, int date, int duration, int size, int dc_id)
		{
			this.id = id;
			this.access_hash = access_hash;
			this.user_id = user_id;
			this.date = date;
			this.duration = duration;
			this.size = size;
			this.dc_id = dc_id;
		}


		public Constructor Constructor
		{
			get { return Constructor.audio; }
		}

		public override void Write(BinaryWriter writer)
		{
			writer.Write(0x427425e7);
			writer.Write(this.id);
			writer.Write(this.access_hash);
			writer.Write(this.user_id);
			writer.Write(this.date);
			writer.Write(this.duration);
			writer.Write(this.size);
			writer.Write(this.dc_id);
		}

		public override void Read(BinaryReader reader)
		{
			this.id = reader.ReadInt64();
			this.access_hash = reader.ReadInt64();
			this.user_id = reader.ReadInt32();
			this.date = reader.ReadInt32();
			this.duration = reader.ReadInt32();
			this.size = reader.ReadInt32();
			this.dc_id = reader.ReadInt32();
		}

		public override string ToString()
		{
			return String.Format("(audio id:{0} access_hash:{1} user_id:{2} date:{3} duration:{4} size:{5} dc_id:{6})", id,
				access_hash, user_id, date, duration, size, dc_id);
		}
	}


	public class DocumentEmptyConstructor : Document
	{
		public long id;

		public DocumentEmptyConstructor()
		{

		}

		public DocumentEmptyConstructor(long id)
		{
			this.id = id;
		}


		public Constructor Constructor
		{
			get { return Constructor.documentEmpty; }
		}

		public override void Write(BinaryWriter writer)
		{
			writer.Write(0x36f8c871);
			writer.Write(this.id);
		}

		public override void Read(BinaryReader reader)
		{
			this.id = reader.ReadInt64();
		}

		public override string ToString()
		{
			return String.Format("(documentEmpty id:{0})", id);
		}
	}


	public class DocumentConstructor : Document
	{
		public long id;
		public long access_hash;
		public int user_id;
		public int date;
		public string file_name;
		public string mime_type;
		public int size;
		public PhotoSize thumb;
		public int dc_id;

		public DocumentConstructor()
		{

		}

		public DocumentConstructor(long id, long access_hash, int user_id, int date, string file_name, string mime_type,
			int size, PhotoSize thumb, int dc_id)
		{
			this.id = id;
			this.access_hash = access_hash;
			this.user_id = user_id;
			this.date = date;
			this.file_name = file_name;
			this.mime_type = mime_type;
			this.size = size;
			this.thumb = thumb;
			this.dc_id = dc_id;
		}


		public Constructor Constructor
		{
			get { return Constructor.document; }
		}

		public override void Write(BinaryWriter writer)
		{
			writer.Write(0x9efc6326);
			writer.Write(this.id);
			writer.Write(this.access_hash);
			writer.Write(this.user_id);
			writer.Write(this.date);
			Serializers.String.write(writer, this.file_name);
			Serializers.String.write(writer, this.mime_type);
			writer.Write(this.size);
			this.thumb.Write(writer);
			writer.Write(this.dc_id);
		}

		public override void Read(BinaryReader reader)
		{
			this.id = reader.ReadInt64();
			this.access_hash = reader.ReadInt64();
			this.user_id = reader.ReadInt32();
			this.date = reader.ReadInt32();
			this.file_name = Serializers.String.read(reader);
			this.mime_type = Serializers.String.read(reader);
			this.size = reader.ReadInt32();
			var tst = Serializers.String.read(reader);
			this.thumb = TL.Parse<PhotoSize>(reader);
			this.dc_id = reader.ReadInt32();
		}

		public override string ToString()
		{
			return
				String.Format(
					"(document id:{0} access_hash:{1} user_id:{2} date:{3} file_name:'{4}' mime_type:'{5}' size:{6} thumb:{7} dc_id:{8})",
					id, access_hash, user_id, date, file_name, mime_type, size, thumb, dc_id);
		}
	}
}

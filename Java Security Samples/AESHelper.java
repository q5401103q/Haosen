package com.haosen.test;

import javax.crypto.Cipher;
import javax.crypto.spec.IvParameterSpec;
import javax.crypto.spec.SecretKeySpec;
import org.apache.commons.codec.binary.Base64;

public class AESHelper {

    // 加密
    public static String encryptByECB(String keyStr, String dataStr) throws Exception
    {
        byte[] raw = keyStr.getBytes("utf-8");
        SecretKeySpec skeySpec = new SecretKeySpec(raw, "AES");
        Cipher cipher = Cipher.getInstance("AES/ECB/PKCS5Padding");//"算法/模式/补码方式"
        cipher.init(Cipher.ENCRYPT_MODE, skeySpec);
        byte[] encrypted = cipher.doFinal(dataStr.getBytes("utf-8"));

        return new Base64().encodeToString(encrypted);//此处使用BASE64做转码功能，同时能起到2次加密的作用。
    }

    // 解密
    public static String decryptByECB(String keyStr, String dataStr) throws Exception {
        byte[] raw = keyStr.getBytes("utf-8");
        SecretKeySpec skeySpec = new SecretKeySpec(raw, "AES");
        Cipher cipher = Cipher.getInstance("AES/ECB/PKCS5Padding");
        cipher.init(Cipher.DECRYPT_MODE, skeySpec);
        byte[] original = cipher.doFinal(new Base64().decode(dataStr));

        return new String(original, "utf-8");
    }

    public static String encryptByCBC(String keyStr, String dataStr, String ivStr) throws Exception {
        byte[] raw = keyStr.getBytes("utf-8");
        byte[] ivb = ivStr.getBytes("utf-8");

        SecretKeySpec skeySpec = new SecretKeySpec(raw, "AES");
        IvParameterSpec ips = new IvParameterSpec(ivb);
        Cipher cipher = Cipher.getInstance("AES/CBC/PKCS5Padding");//"算法/模式/补码方式"
        cipher.init(Cipher.ENCRYPT_MODE, skeySpec, ips);
        byte[] encrypted = cipher.doFinal(dataStr.getBytes("utf-8"));

        return new Base64().encodeToString(encrypted);//此处使用BASE64做转码功能，同时能起到2次加密的作用。
    }

    public static String decryptByCBC(String keyStr, String dataStr, String ivStr) throws Exception {
        byte[] raw = keyStr.getBytes("utf-8");
        byte[] ivb = ivStr.getBytes("utf-8");

        SecretKeySpec skeySpec = new SecretKeySpec(raw, "AES");
        IvParameterSpec ips = new IvParameterSpec(ivb);
        Cipher cipher = Cipher.getInstance("AES/CBC/PKCS5Padding");
        cipher.init(Cipher.DECRYPT_MODE, skeySpec, ips);
        byte[] original = cipher.doFinal(new Base64().decode(dataStr));

        return new String(original, "utf-8");
    }
}
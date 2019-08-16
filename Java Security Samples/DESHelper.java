package com.haosen.test;

import javax.crypto.Cipher;
import javax.crypto.SecretKeyFactory;
import javax.crypto.spec.DESedeKeySpec;
import javax.crypto.spec.IvParameterSpec;
import java.security.Key;
import org.apache.commons.codec.binary.Base64;

public class DESHelper
{
    /**
     * ECB加密,不要IV
     * @param keyStr 密钥
     * @param dataStr 明文
     * @return Base64编码的密文
     * @throws Exception
     */
    public static String encryptByECB(String keyStr, String dataStr)
            throws Exception {
        byte[] key = keyStr.getBytes("utf-8");
        byte[] data = dataStr.getBytes("utf-8");

        Key deskey = null;
        DESedeKeySpec spec = new DESedeKeySpec(key);
        SecretKeyFactory keyfactory = SecretKeyFactory.getInstance("desede");
        deskey = keyfactory.generateSecret(spec);
        Cipher cipher = Cipher.getInstance("desede" + "/ECB/PKCS5Padding");
        cipher.init(Cipher.ENCRYPT_MODE, deskey);
        byte[] bOut = cipher.doFinal(data);
        return new Base64().encodeToString(bOut);
    }

    /**
     * ECB解密,不要IV
     * @param keyStr 密钥
     * @param dataStr Base64编码的密文
     * @return 明文
     * @throws Exception
     */
    public static String decryptByECB(String keyStr, String dataStr)
            throws Exception {
        byte[] key = keyStr.getBytes("utf-8");
        byte[] data = dataStr.getBytes("utf-8");
        Key deskey = null;
        DESedeKeySpec spec = new DESedeKeySpec(key);
        SecretKeyFactory keyfactory = SecretKeyFactory.getInstance("desede");
        deskey = keyfactory.generateSecret(spec);
        Cipher cipher = Cipher.getInstance("desede" + "/ECB/PKCS5Padding");
        cipher.init(Cipher.DECRYPT_MODE, deskey);
        byte[] bOut = cipher.doFinal(data);
        return new String(bOut);
    }
    /**
     * CBC加密
     * @param keyStr 密钥
     * @param ivStr IV
     * @param dataStr 明文
     * @return Base64编码的密文
     * @throws Exception
     */
    public static String encryptByCBC(String keyStr, String dataStr, String ivStr)
            throws Exception {
        byte[] key = keyStr.getBytes("utf-8");
        byte[] data = dataStr.getBytes("utf-8");
        byte[] iv = ivStr.getBytes("utf-8");
        Key deskey = null;
        DESedeKeySpec spec = new DESedeKeySpec(key);
        SecretKeyFactory keyfactory = SecretKeyFactory.getInstance("desede");
        deskey = keyfactory.generateSecret(spec);
        Cipher cipher = Cipher.getInstance("desede" + "/CBC/PKCS5Padding");
        IvParameterSpec ips = new IvParameterSpec(iv);
        cipher.init(Cipher.ENCRYPT_MODE, deskey, ips);
        byte[] bOut = cipher.doFinal(data);
        return new Base64().encodeToString(bOut);
    }
    /**
     * CBC解密
     * @param keyStr 密钥
     * @param ivStr IV
     * @param dataStr Base64编码的密文
     * @return 明文
     * @throws Exception
     */
    public static String decryptByCBC(String keyStr, String dataStr, String ivStr)
            throws Exception {
        byte[] key = keyStr.getBytes("utf-8");
        byte[] data = dataStr.getBytes("utf-8");
        byte[] iv = ivStr.getBytes("utf-8");
        Key deskey = null;
        DESedeKeySpec spec = new DESedeKeySpec(key);
        SecretKeyFactory keyfactory = SecretKeyFactory.getInstance("desede");
        deskey = keyfactory.generateSecret(spec);
        Cipher cipher = Cipher.getInstance("desede" + "/CBC/PKCS5Padding");
        IvParameterSpec ips = new IvParameterSpec(iv);
        cipher.init(Cipher.DECRYPT_MODE, deskey, ips);
        byte[] bOut = cipher.doFinal(data);
        return new String(bOut);
    }
}

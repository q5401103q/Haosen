package com.haosen.test;

import javax.print.DocFlavor;

public class Main
{
    public static void main(String[] args) throws Exception
    {
        String key = "123456789012345678901234";
        String str = "今天是星期五，希望年会可以抽到索尼耳机";
        String aesIv = "abcdefgh12345678";
        String desIv = "abcdefgh";

        System.out.println("AES:");
        System.out.println("CBC:" + AESHelper.encryptByCBC(key,str, aesIv));
        System.out.println("ECB:" + AESHelper.encryptByECB(key,str));
        System.out.println();
        System.out.println("DES:");
        System.out.println("CBC:" + DESHelper.encryptByCBC(key,str, desIv));
        System.out.println("ECB:" + DESHelper.encryptByECB(key,str));
    }
}

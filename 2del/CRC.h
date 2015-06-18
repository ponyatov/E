#ifndef _H_CRC
#define _H_CRC

class CRC {
	// CRC generator polynome
	static const char poly = 0x89; // sample for CRC7
	// fast CRC calc table
	char table[0x100];
	// generate table using crc gen. poly
	void gentable(void);
	// calc. crc via table adding one byte
	char crc_add(char *table, char crc0, char nextbyte);
	char crc_byte(char *table, char *buf, int len);
public:
	CRC();
	// calc crc for byte buffer
	char crc(char *buf, int sz);
	// dump (generated or statically compiled) table
	void dumptable(void);
};

class CRC7: public CRC {
	static const char poly = 0x89;
	static const char table[0x100];
public:
};

#endif // _H_CRC

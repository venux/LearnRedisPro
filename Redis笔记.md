# http://try.redis.io/

## 键值对
- SET TESTKEY "TESTVALUE",设置键值对TESTKEY-"TESTVALUE"，返回OK；
- GET TESTKEY,获取键TESTKEY的值（获取不存在的键的值返回nil，即空）；
- DEL TESTKEY,删除键为TESTKEY的键值对，成功返回1；
- INCR TESTKEY,自动加一，成功返回结果（若TESTKEY不是int值，则报错）`注意：INCR命令是原子操作（即不会被线程调度机制打断的操作）`;
- SETNX TEST1 'TESTVALUE'，若键不存在则设置，若键存在则不设置，成功返回1，失败返回0；
- EXPIRE TESTKEY 120,设置键TESTKEY有效期120秒；
- TTL TESTKEY,查看键TESTKEY剩余有效期,-2表示键已过期不存在，-1表示永不过期，若重下SET TESTKEY，则状态重置为-1;

## 数据结构

### 列表（list）有序、可重复
- RPUSH TESTLIST "ITEM1",插入一项到列表尾部，返回列表子项个数；
- LPUSH TESTLIST "ITEM2",插入一项到列表头部，返回列表子项个数；
- LRANGE TESTLIST 0 -1,列出列表子项，参数1表示从第0个开始，参数2表示到第N个（-1表示最后）；
- LLEN TESTLIST,获取列表子项个数；
- LPOP TESTLIST,移除列表头部项，返回项的值；
- RPOP TESTLIST,移除列表尾部项，返回项的值；

### 集合（set）无序、不可重复
- SADD TESTSET "ITEM1",插入一项到集合中，返回1表示成功，若已有该项则返回0；
- SREM TESTSET "ITEM1",从集合中移除指定项，返回1表示成功，若无该项则返回0；
- SISMEMBER TESTSET "ITEM1"，验证指定项是否在集合中，0否1是；
- SMEMBERS TESTSET，列出集合项
- SUNION TESTSET1 TEST2 ... TESTN,合并多个集合，返回并集（无序无重复项）；

### 有序集合（sorted set）有序、不可重复
- ZADD TESTSORTSET 3 "C",3为关联值，用于排序，float；
- ZRANGE TESTSORTLIST 0 -1,列出有序集合子项，参数1表示从第0个开始，参数2表示到第N个（-1表示最后）；

### 哈希（Hashes）用于保存对象
- HSET obj name 'venux';HSET obj age '27';HSET obj email '337225164@qq.com',保存一个obj对象，单个属性存放用户名、年龄、email。
- HMSET obj name 'venux' age '27' email '337225164@qq.com',保存一个obj对象，多个属性存放用户名、年龄、email。
- HGETALL obj,获取obj对象
- HGET obj name,获取obj对象的name属性
- HINCRBY obj age 10,给obj对象的age属性加10，Hash字段中数值类型使用同等的字符串表示，并能通过`HINCRBY`（原子操作）累加

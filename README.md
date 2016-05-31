# MDORM

Mini Dapper ORM（迷你DapperORM）。一款基于Dapper ORM扩展的迷你型ORM，有助于提高开发效率。

Dapper是一个轻型的ORM类。代码就一个SqlMapper.cs文件。编译后就一个很小的Dll.

Dapper通过Emit反射IDataReader的序列队列来快速的得到和产生对象。性能很牛逼,速度很快。Dapper的速度接近与IDataReader，取列表的数据超过了DataTable。

Dapper支持Mysql,SqlLite,Mssql等一系列的数据库，当然如果你知道原理也可以让它支持Mongo db.

Dapper没侵入性，想用就用，不想用就不用。无XML无属性。代码以前怎么写现在还怎么写。

Dapper的语法是这样的。语法十分简单。并且无须迁就数据库的设计。

MDORM在Dapper的基础上封装了节本CRUD操作（Get, Insert, Update, Delete）支持对数据库对象表、视图、存储过程常用操作，对更高级的查询场景，该类库还提供了一套谓词系统。它的目标是保持POCOs的纯净，不需要额外的attributes和类的继承。使得一些简单的数据库操作可以不用自己写sql语句。使用起来更方面，大大提高开发效率。

表操作目前封装的方法：

	/// <summary>
	/// 通过ID获取单条记录
	/// </summary>
	/// <param name="primaryId">动态类型的ID</param>
	/// <returns>单个实体</returns>
	T GetById(object primaryId);

	/// <summary>
	/// 获取全部记录
	/// </summary>
	/// <returns>全部记录</returns>
	List<T> GetAll();

	/// <summary>
	/// 获取满足条件的记录条数
	/// </summary>
	/// <param name="predicate">查找条件</param>
	/// <returns>满足条件的数据条数</returns>
	int Count(object predicate);

	/// <summary>
	/// 获取满足条件的数据列表
	/// </summary>
	/// <param name="predicate">查询条件</param>
	/// <param name="sort">排序列表</param>
	/// <param name="buffered">是否缓存</param>
	/// <returns>满足条件的数据列表</returns>
	List<T> GetList(object predicate = null, IList<ISort> sort = null, bool buffered = false);

	/// <summary>
	/// 分页获取数据
	/// </summary>
	/// <param name="pageIndex">页索引</param>
	/// <param name="pageSize">页大小</param>
	/// <param name="allRowsCount">全部记录数</param>
	/// <param name="predicate">查询条件</param>
	/// <param name="sort">排序</param>
	/// <param name="buffered">是否缓存</param>
	/// <returns>当前页数据</returns>
	List<T> GetPage(int pageIndex, int pageSize, out int allRowsCount, object predicate = null, IList<ISort> sort = null, bool buffered = true);

	/// <summary>
	/// 插入一条数据并返回该记录ID
	/// </summary>
	/// <param name="entity">数据实体</param>
	/// <returns>该记录ID</returns>
	dynamic Insert(T entity);

	/// <summary>
	/// 使用事务批量插入
	/// </summary>
	/// <param name="entityList">实体列表</param>
	/// <returns>是否成功</returns>
	bool InsertBatch(IEnumerable<T> entityList);

	/// <summary>
	/// 更新一条数据
	/// </summary>
	/// <param name="entity">一个实体（主键必须有，其他的按需要更新）</param>
	/// <returns>是否成功</returns>
	bool Update(T entity);

	/// <summary>
	/// 使用事务批量更新
	/// </summary>
	/// <param name="entityList">要更新的实体列表</param>
	/// <returns>是否成功</returns>
	bool UpdateBatch(IEnumerable<T> entityList);

	/// <summary>
	/// 删除满足条件的数据
	/// </summary>
	/// <param name="predicate">条件</param>
	/// <returns>是否成功</returns>
	bool Delete(object predicate);

	/// <summary>
	/// 使用事务删除满足条件的数据
	/// </summary>
	/// <param name="predicate">条件</param>
	/// <returns>是否成功</returns>
	bool DeleteList(object predicate);

	/// <summary>
	/// 使用事务批量删除
	/// </summary>
	/// <param name="ids">ID列表</param>
	/// <returns>是否成功</returns>
	bool DeleteBatch(IEnumerable<object> ids);
    
视图操作目前封装的方法：

    /// <summary>
    /// 获取全部记录
    /// </summary>
    /// <returns>全部记录</returns>
    List<T> GetAll();

    /// <summary>
    /// 获取记录条数
    /// </summary>
    /// <param name="predicate">查找条件</param>
    /// <returns>满足条件的数据条数</returns>
    int Count(object predicate);

    /// <summary>
    /// 获取数据列表
    /// </summary>
    /// <param name="predicate">查询条件</param>
    /// <param name="sort">排序</param>
    /// <param name="buffered">是否缓存</param>
    /// <returns>满足条件的数据列表</returns>
    List<T> GetList(object predicate = null, IList<ISort> sort = null, bool buffered = false);

    /// <summary>
    /// 分页获取数据
    /// </summary>
    /// <param name="pageIndex">页索引</param>
    /// <param name="pageSize">页大小</param>
    /// <param name="allRowsCount">全部记录数</param>
    /// <param name="predicate">查询条件</param>
    /// <param name="sort">排序</param>
    /// <param name="buffered">是否缓存</param>
    /// <returns>当前页数据</returns>
    List<T> GetPage(int pageIndex, int pageSize, out int allRowsCount, object predicate = null, IList<ISort> sort = null, bool buffered = true);
    
存储过程操作按需要调用MDORM.DBUtitily中中的DBHelper方法。
详细示例见方案中的MDORM.Test项目

作者：朱明明（Berton）
邮箱：zhumingming1040@163.com、zhumingming1040@hotmail.com
QQ：937553351
